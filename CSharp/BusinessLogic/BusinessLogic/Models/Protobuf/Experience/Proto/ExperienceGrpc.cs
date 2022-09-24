// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Proto/Experience.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Networking.Experience {
  public static partial class ExperienceService
  {
    static readonly string __ServiceName = "networking.experience.ExperienceService";

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
    static readonly grpc::Marshaller<global::Networking.Request.RequestMessage> __Marshaller_networking_request_RequestMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Request.RequestMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Experience.ExperienceListMessage> __Marshaller_networking_experience_ExperienceListMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Experience.ExperienceListMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Request.PageRequestMessage> __Marshaller_networking_request_PageRequestMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Request.PageRequestMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Networking.Experience.ExperienceMessage> __Marshaller_networking_experience_ExperienceMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Networking.Experience.ExperienceMessage.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage> __Method_getAllProviderExperiences = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getAllProviderExperiences",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_experience_ExperienceListMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.PageRequestMessage, global::Networking.Experience.ExperienceListMessage> __Method_getAllWebShopExperiences = new grpc::Method<global::Networking.Request.PageRequestMessage, global::Networking.Experience.ExperienceListMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getAllWebShopExperiences",
        __Marshaller_networking_request_PageRequestMessage,
        __Marshaller_networking_experience_ExperienceListMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Experience.ExperienceMessage, global::Networking.Experience.ExperienceMessage> __Method_addExperience = new grpc::Method<global::Networking.Experience.ExperienceMessage, global::Networking.Experience.ExperienceMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "addExperience",
        __Marshaller_networking_experience_ExperienceMessage,
        __Marshaller_networking_experience_ExperienceMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceMessage> __Method_getExperienceById = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getExperienceById",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_experience_ExperienceMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Request.RequestMessage> __Method_isInStock = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Request.RequestMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "isInStock",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_request_RequestMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Request.RequestMessage> __Method_deleteExperience = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Request.RequestMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "deleteExperience",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_request_RequestMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Request.RequestMessage> __Method_removeStock = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Request.RequestMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "removeStock",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_request_RequestMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage> __Method_getAllProviderExperiencesByName = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getAllProviderExperiencesByName",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_experience_ExperienceListMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage> __Method_getExperienceByCategory = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getExperienceByCategory",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_experience_ExperienceListMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage> __Method_getTopExperiences = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getTopExperiences",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_experience_ExperienceListMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage> __Method_getSortedExperiences = new grpc::Method<global::Networking.Request.RequestMessage, global::Networking.Experience.ExperienceListMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getSortedExperiences",
        __Marshaller_networking_request_RequestMessage,
        __Marshaller_networking_experience_ExperienceListMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Networking.Experience.ExperienceMessage, global::Networking.Experience.ExperienceMessage> __Method_editExperience = new grpc::Method<global::Networking.Experience.ExperienceMessage, global::Networking.Experience.ExperienceMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "editExperience",
        __Marshaller_networking_experience_ExperienceMessage,
        __Marshaller_networking_experience_ExperienceMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Networking.Experience.ExperienceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ExperienceService</summary>
    public partial class ExperienceServiceClient : grpc::ClientBase<ExperienceServiceClient>
    {
      /// <summary>Creates a new client for ExperienceService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ExperienceServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ExperienceService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ExperienceServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ExperienceServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ExperienceServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getAllProviderExperiences(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getAllProviderExperiences(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getAllProviderExperiences(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getAllProviderExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getAllProviderExperiencesAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getAllProviderExperiencesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getAllProviderExperiencesAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getAllProviderExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getAllWebShopExperiences(global::Networking.Request.PageRequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getAllWebShopExperiences(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getAllWebShopExperiences(global::Networking.Request.PageRequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getAllWebShopExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getAllWebShopExperiencesAsync(global::Networking.Request.PageRequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getAllWebShopExperiencesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getAllWebShopExperiencesAsync(global::Networking.Request.PageRequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getAllWebShopExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceMessage addExperience(global::Networking.Experience.ExperienceMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return addExperience(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceMessage addExperience(global::Networking.Experience.ExperienceMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_addExperience, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceMessage> addExperienceAsync(global::Networking.Experience.ExperienceMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return addExperienceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceMessage> addExperienceAsync(global::Networking.Experience.ExperienceMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_addExperience, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceMessage getExperienceById(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getExperienceById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceMessage getExperienceById(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getExperienceById, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceMessage> getExperienceByIdAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getExperienceByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceMessage> getExperienceByIdAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getExperienceById, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Request.RequestMessage isInStock(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return isInStock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Request.RequestMessage isInStock(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_isInStock, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Request.RequestMessage> isInStockAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return isInStockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Request.RequestMessage> isInStockAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_isInStock, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Request.RequestMessage deleteExperience(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return deleteExperience(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Request.RequestMessage deleteExperience(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_deleteExperience, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Request.RequestMessage> deleteExperienceAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return deleteExperienceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Request.RequestMessage> deleteExperienceAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_deleteExperience, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Request.RequestMessage removeStock(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return removeStock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Request.RequestMessage removeStock(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_removeStock, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Request.RequestMessage> removeStockAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return removeStockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Request.RequestMessage> removeStockAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_removeStock, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getAllProviderExperiencesByName(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getAllProviderExperiencesByName(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getAllProviderExperiencesByName(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getAllProviderExperiencesByName, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getAllProviderExperiencesByNameAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getAllProviderExperiencesByNameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getAllProviderExperiencesByNameAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getAllProviderExperiencesByName, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getExperienceByCategory(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getExperienceByCategory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getExperienceByCategory(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getExperienceByCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getExperienceByCategoryAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getExperienceByCategoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getExperienceByCategoryAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getExperienceByCategory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getTopExperiences(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getTopExperiences(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getTopExperiences(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getTopExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getTopExperiencesAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getTopExperiencesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getTopExperiencesAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getTopExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getSortedExperiences(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getSortedExperiences(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceListMessage getSortedExperiences(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getSortedExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getSortedExperiencesAsync(global::Networking.Request.RequestMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getSortedExperiencesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceListMessage> getSortedExperiencesAsync(global::Networking.Request.RequestMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getSortedExperiences, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceMessage editExperience(global::Networking.Experience.ExperienceMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return editExperience(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Networking.Experience.ExperienceMessage editExperience(global::Networking.Experience.ExperienceMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_editExperience, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceMessage> editExperienceAsync(global::Networking.Experience.ExperienceMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return editExperienceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Networking.Experience.ExperienceMessage> editExperienceAsync(global::Networking.Experience.ExperienceMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_editExperience, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ExperienceServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ExperienceServiceClient(configuration);
      }
    }

  }
}
#endregion