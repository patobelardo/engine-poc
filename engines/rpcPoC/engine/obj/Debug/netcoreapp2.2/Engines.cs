// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: engines.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Engine {

  /// <summary>Holder for reflection information generated from engines.proto</summary>
  public static partial class EnginesReflection {

    #region Descriptor
    /// <summary>File descriptor for engines.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static EnginesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg1lbmdpbmVzLnByb3RvEgZlbmdpbmUiJQoNRW5naW5lUmVxdWVzdBIUCgxp",
            "bnB1dE1lc3NhZ2UYASABKAkiJgoLRW5naW5lUmVwbHkSFwoPcmVzcG9uc2VN",
            "ZXNzYWdlGAEgASgJMkUKCkVuZ2luZVdvcmsSNwoHRXhlY3V0ZRIVLmVuZ2lu",
            "ZS5FbmdpbmVSZXF1ZXN0GhMuZW5naW5lLkVuZ2luZVJlcGx5IgBiBnByb3Rv",
            "Mw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Engine.EngineRequest), global::Engine.EngineRequest.Parser, new[]{ "InputMessage" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Engine.EngineReply), global::Engine.EngineReply.Parser, new[]{ "ResponseMessage" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The request message containing the user's name.
  /// </summary>
  public sealed partial class EngineRequest : pb::IMessage<EngineRequest> {
    private static readonly pb::MessageParser<EngineRequest> _parser = new pb::MessageParser<EngineRequest>(() => new EngineRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EngineRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Engine.EnginesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EngineRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EngineRequest(EngineRequest other) : this() {
      inputMessage_ = other.inputMessage_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EngineRequest Clone() {
      return new EngineRequest(this);
    }

    /// <summary>Field number for the "inputMessage" field.</summary>
    public const int InputMessageFieldNumber = 1;
    private string inputMessage_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string InputMessage {
      get { return inputMessage_; }
      set {
        inputMessage_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EngineRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EngineRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InputMessage != other.InputMessage) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InputMessage.Length != 0) hash ^= InputMessage.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (InputMessage.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(InputMessage);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (InputMessage.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(InputMessage);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EngineRequest other) {
      if (other == null) {
        return;
      }
      if (other.InputMessage.Length != 0) {
        InputMessage = other.InputMessage;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            InputMessage = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// The response message containing the greetings
  /// </summary>
  public sealed partial class EngineReply : pb::IMessage<EngineReply> {
    private static readonly pb::MessageParser<EngineReply> _parser = new pb::MessageParser<EngineReply>(() => new EngineReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EngineReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Engine.EnginesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EngineReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EngineReply(EngineReply other) : this() {
      responseMessage_ = other.responseMessage_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EngineReply Clone() {
      return new EngineReply(this);
    }

    /// <summary>Field number for the "responseMessage" field.</summary>
    public const int ResponseMessageFieldNumber = 1;
    private string responseMessage_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ResponseMessage {
      get { return responseMessage_; }
      set {
        responseMessage_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EngineReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EngineReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ResponseMessage != other.ResponseMessage) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ResponseMessage.Length != 0) hash ^= ResponseMessage.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ResponseMessage.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ResponseMessage);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ResponseMessage.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ResponseMessage);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EngineReply other) {
      if (other == null) {
        return;
      }
      if (other.ResponseMessage.Length != 0) {
        ResponseMessage = other.ResponseMessage;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ResponseMessage = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
