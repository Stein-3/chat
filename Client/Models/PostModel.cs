﻿using ChatApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ChatApp.Client.Models
{
    public delegate void ChangePostMessage();

    public delegate void ChangeThreadCountEventHandler();

    public class PostModel : ICreateAndUpdateDate
    {

        public List<ThreadModel> ThreadModels { get; set; }

        public string UserEmail { get; set; }

        public string HandleName { get; set; }

        public Guid PostId { get; init; }

        public string MessageContext { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public event ChangePostMessage ChangePost;

        public event ChangeThreadCountEventHandler ChangeThread;

        public async Task ChangeMessage(ChatPostUpdateRequest request, HttpClient httpClient)
        {
            await httpClient.PutAsJsonAsync($"Post/{PostId}", request);

            MessageContext = request.Text;

            ChangePost();
        }

        public async Task SendThreadMessage(ThreadMessage message, HttpClient httpClient)
        {
            var response = await httpClient.PostAsJsonAsync("Post", message);

            var threadMessage = await response.Content.ReadFromJsonAsync<ThreadMessage>();

            ThreadModels.Add(new ThreadModel()
            {
                UserEmail = threadMessage.UserEmail,
                HandleName = threadMessage.HandleName,
                ThreadId = threadMessage.ThreadId,
                MessageContext = threadMessage.MessageContext,
                CreateDate = threadMessage.CreateDate
            });

            ChangeThread();
        }

        public async Task DeleteThreadMessage(Guid threadId, HttpClient httpClient)
        {
            await httpClient.DeleteAsync($"Thread/{threadId}");

            var deletedThread = ThreadModels.FirstOrDefault(thread => thread.ThreadId == threadId);
            ThreadModels.Remove(deletedThread);

            ChangeThread();
        }

    }
}
