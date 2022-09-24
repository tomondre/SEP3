// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Proto/Provider.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Networking.Provider {
  public static partial class ProviderService
  {
    static readonly string __ServiceName = "networking.provider.ProviderService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Provider.ProviderMessage> __Marshaller_networking_provider_ProviderMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Provider.ProviderMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.User.UserMessage> __Marshaller_networking_user_UserMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.User.UserMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Request.PageRequestMessage> __Marshaller_networking_request_PageRequestMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Request.PageRequestMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Provider.ProvidersMessage> __Marshaller_networking_provider_ProvidersMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Provider.ProvidersMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Request.RequestMessage> __Marshaller_networking_request_RequestMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Request.RequestMessage.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Provider.ProviderMessage, global::Networking.User.UserMessage> __Method_CreateProvider = new grpc::Method<global::Networking.Provider.ProviderMessage, global::Networking.User.UserMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateProvider",
        __Marshaller_networking_provider_ProviderMessage,
        __Marshaller_networking_user_UserMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.PageRequestMessage, global::Networking.Provider.ProvidersMessage> __Method_GetAllProviders = new grpc::Method<global::Networking.Request.PageRequestMessage, global::Networking.Provider.ProvidersMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllProviders",
        __Marshaller_networking_request_PageRequestMessage,
        __Marshaller_networking_provider_ProvidersMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Provider.ProviderMessage> __Method_GetProviderById = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Provider.ProviderMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProviderById",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_provider_ProviderMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Provider.ProviderMessage, global::Networking.Provider.ProviderMessage> __Method_EditProvider = new grpc::Method<global::Networking.Provider.ProviderMessage, global::Networking.Provider.ProviderMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "EditProvider",
        __Marshaller_networking_provider_ProviderMessage,
        __Marshaller_networking_provider_ProviderMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Provider.ProviderMessage> __Method_RemoveProvider = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Provider.ProviderMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveProvider",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_provider_ProviderMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.PageRequestMessage, global::Networking.Provider.ProvidersMessage> __Method_GetAllNotApprovedProviders = new grpc::Method<global::Networking.Request.PageRequestMessage, global::Networking.Provider.ProvidersMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllNotApprovedProviders",
        __Marshaller_networking_request_PageRequestMessage,
        __Marshaller_networking_provider_ProvidersMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Provider.ProvidersMessage> __Method_GetAllByName = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Provider.ProvidersMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllByName",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_provider_ProvidersMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Networking.Provider.ProviderReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ProviderService</summary>
    public partial class ProviderServiceClient : grpc::ClientBase<ProviderServiceClient>
    {
      /// <summary>Creates a new client for ProviderService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ProviderServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ProviderService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ProviderServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ProviderServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ProviderServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.User.UserMessage CreateProvider(global::Networking.Provider.ProviderMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateProvider(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.User.UserMessage CreateProvider(global::Networking.Provider.ProviderMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateProvider, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.User.UserMessage> CreateProviderAsync(global::Networking.Provider.ProviderMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateProviderAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.User.UserMessage> CreateProviderAsync(global::Networking.Provider.ProviderMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateProvider, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProvidersMessage GetAllProviders(global::Networking.Request.PageRequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllProviders(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProvidersMessage GetAllProviders(global::Networking.Request.PageRequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllProviders, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProvidersMessage> GetAllProvidersAsync(global::Networking.Request.PageRequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllProvidersAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProvidersMessage> GetAllProvidersAsync(global::Networking.Request.PageRequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllProviders, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProviderMessage GetProviderById(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetProviderById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProviderMessage GetProviderById(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetProviderById, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProviderMessage> GetProviderByIdAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetProviderByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProviderMessage> GetProviderByIdAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetProviderById, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProviderMessage EditProvider(global::Networking.Provider.ProviderMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EditProvider(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProviderMessage EditProvider(global::Networking.Provider.ProviderMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_EditProvider, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProviderMessage> EditProviderAsync(global::Networking.Provider.ProviderMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EditProviderAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProviderMessage> EditProviderAsync(global::Networking.Provider.ProviderMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_EditProvider, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProviderMessage RemoveProvider(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveProvider(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProviderMessage RemoveProvider(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RemoveProvider, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProviderMessage> RemoveProviderAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveProviderAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProviderMessage> RemoveProviderAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RemoveProvider, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProvidersMessage GetAllNotApprovedProviders(global::Networking.Request.PageRequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllNotApprovedProviders(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProvidersMessage GetAllNotApprovedProviders(global::Networking.Request.PageRequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllNotApprovedProviders, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProvidersMessage> GetAllNotApprovedProvidersAsync(global::Networking.Request.PageRequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllNotApprovedProvidersAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProvidersMessage> GetAllNotApprovedProvidersAsync(global::Networking.Request.PageRequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllNotApprovedProviders, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProvidersMessage GetAllByName(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllByName(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Provider.ProvidersMessage GetAllByName(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllByName, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProvidersMessage> GetAllByNameAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllByNameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Provider.ProvidersMessage> GetAllByNameAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllByName, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ProviderServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ProviderServiceClient(configuration);
      }
    }

  }
}
#endregion
