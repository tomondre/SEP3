using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLogic.Networking.User;
using GrpcFileGeneration.Models;
using Networking.Category;
using Networking.User;
using ProtobufMessage = Networking.Category.ProtobufMessage;

namespace BusinessLogic.Networking.User
{
    public class UserNet : IUserNet
    {
        private UserService.UserServiceClient client;

        public UserNet(UserService.UserServiceClient client)
        {
            this.client = client;
        }


        public void AddProductCategoryAsync()
        {
            client.createUser(new global::Networking.User.ProtobufMessage(){MessageOrObject = " "});
        }
    }
}