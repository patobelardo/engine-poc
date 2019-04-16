// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: engines.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Engine {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class EngineWork
  {
    static readonly string __ServiceName = "engine.EngineWork";

    static readonly grpc::Marshaller<global::Engine.EngineRequest> __Marshaller_engine_EngineRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Engine.EngineRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Engine.EngineReply> __Marshaller_engine_EngineReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Engine.EngineReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Engine.EngineRequest, global::Engine.EngineReply> __Method_Execute = new grpc::Method<global::Engine.EngineRequest, global::Engine.EngineReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Execute",
        __Marshaller_engine_EngineRequest,
        __Marshaller_engine_EngineReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Engine.EnginesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of EngineWork</summary>
    public abstract partial class EngineWorkBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Engine.EngineReply> Execute(global::Engine.EngineRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for EngineWork</summary>
    public partial class EngineWorkClient : grpc::ClientBase<EngineWorkClient>
    {
      /// <summary>Creates a new client for EngineWork</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public EngineWorkClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for EngineWork that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public EngineWorkClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected EngineWorkClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected EngineWorkClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Engine.EngineReply Execute(global::Engine.EngineRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Execute(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Engine.EngineReply Execute(global::Engine.EngineRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Execute, null, options, request);
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Engine.EngineReply> ExecuteAsync(global::Engine.EngineRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ExecuteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Engine.EngineReply> ExecuteAsync(global::Engine.EngineRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Execute, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override EngineWorkClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new EngineWorkClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(EngineWorkBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Execute, serviceImpl.Execute).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, EngineWorkBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Execute, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Engine.EngineRequest, global::Engine.EngineReply>(serviceImpl.Execute));
    }

  }
}
#endregion