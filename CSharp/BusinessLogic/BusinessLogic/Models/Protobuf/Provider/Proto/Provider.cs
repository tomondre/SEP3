// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Proto/Provider.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Networking.Provider {

  /// <summary>Holder for reflection information generated from Proto/Provider.proto</summary>
  public static partial class ProviderReflection {

    #region Descriptor
    /// <summary>File descriptor for Proto/Provider.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ProviderReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRQcm90by9Qcm92aWRlci5wcm90bxITbmV0d29ya2luZy5wcm92aWRlchoT",
            "UHJvdG8vQWRkcmVzcy5wcm90bxoQUHJvdG8vVXNlci5wcm90bxoQUHJvdG8v",
            "UGFnZS5wcm90bxoTUHJvdG8vUmVxdWVzdC5wcm90byLVAQoPUHJvdmlkZXJN",
            "ZXNzYWdlEioKBHVzZXIYASABKAsyHC5uZXR3b3JraW5nLnVzZXIuVXNlck1l",
            "c3NhZ2USFAoMY29tcGFueV9uYW1lGAIgASgJEgsKA2N2chgDIAEoBRIUCgxw",
            "aG9uZV9udW1iZXIYBCABKAkSEwoLZGVzY3JpcHRpb24YBSABKAkSEwoLaXNf",
            "YXBwcm92ZWQYBiABKAgSMwoHYWRkcmVzcxgHIAEoCzIiLm5ldHdvcmtpbmcu",
            "YWRkcmVzcy5BZGRyZXNzTWVzc2FnZSJ7ChBQcm92aWRlcnNNZXNzYWdlEjcK",
            "CXByb3ZpZGVycxgBIAMoCzIkLm5ldHdvcmtpbmcucHJvdmlkZXIuUHJvdmlk",
            "ZXJNZXNzYWdlEi4KCHBhZ2VJbmZvGAIgASgLMhwubmV0d29ya2luZy5wYWdl",
            "LlBhZ2VNZXNzYWdlMqYFCg9Qcm92aWRlclNlcnZpY2USVAoOQ3JlYXRlUHJv",
            "dmlkZXISJC5uZXR3b3JraW5nLnByb3ZpZGVyLlByb3ZpZGVyTWVzc2FnZRoc",
            "Lm5ldHdvcmtpbmcudXNlci5Vc2VyTWVzc2FnZRJgCg9HZXRBbGxQcm92aWRl",
            "cnMSJi5uZXR3b3JraW5nLnJlcXVlc3QuUGFnZVJlcXVlc3RNZXNzYWdlGiUu",
            "bmV0d29ya2luZy5wcm92aWRlci5Qcm92aWRlcnNNZXNzYWdlElsKD0dldFBy",
            "b3ZpZGVyQnlJZBIiLm5ldHdvcmtpbmcucmVxdWVzdC5SZXF1ZXN0TWVzc2Fn",
            "ZRokLm5ldHdvcmtpbmcucHJvdmlkZXIuUHJvdmlkZXJNZXNzYWdlEloKDEVk",
            "aXRQcm92aWRlchIkLm5ldHdvcmtpbmcucHJvdmlkZXIuUHJvdmlkZXJNZXNz",
            "YWdlGiQubmV0d29ya2luZy5wcm92aWRlci5Qcm92aWRlck1lc3NhZ2USWgoO",
            "UmVtb3ZlUHJvdmlkZXISIi5uZXR3b3JraW5nLnJlcXVlc3QuUmVxdWVzdE1l",
            "c3NhZ2UaJC5uZXR3b3JraW5nLnByb3ZpZGVyLlByb3ZpZGVyTWVzc2FnZRJr",
            "ChpHZXRBbGxOb3RBcHByb3ZlZFByb3ZpZGVycxImLm5ldHdvcmtpbmcucmVx",
            "dWVzdC5QYWdlUmVxdWVzdE1lc3NhZ2UaJS5uZXR3b3JraW5nLnByb3ZpZGVy",
            "LlByb3ZpZGVyc01lc3NhZ2USWQoMR2V0QWxsQnlOYW1lEiIubmV0d29ya2lu",
            "Zy5yZXF1ZXN0LlJlcXVlc3RNZXNzYWdlGiUubmV0d29ya2luZy5wcm92aWRl",
            "ci5Qcm92aWRlcnNNZXNzYWdlQgJQAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Networking.Address.AddressReflection.Descriptor, global::Networking.User.UserReflection.Descriptor, global::Networking.Page.PageReflection.Descriptor, global::Networking.Request.RequestReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Networking.Provider.ProviderMessage), global::Networking.Provider.ProviderMessage.Parser, new[]{ "User", "CompanyName", "Cvr", "PhoneNumber", "Description", "IsApproved", "Address" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Networking.Provider.ProvidersMessage), global::Networking.Provider.ProvidersMessage.Parser, new[]{ "Providers", "PageInfo" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ProviderMessage : pb::IMessage<ProviderMessage>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProviderMessage> _parser = new pb::MessageParser<ProviderMessage>(() => new ProviderMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProviderMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Networking.Provider.ProviderReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProviderMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProviderMessage(ProviderMessage other) : this() {
      user_ = other.user_ != null ? other.user_.Clone() : null;
      companyName_ = other.companyName_;
      cvr_ = other.cvr_;
      phoneNumber_ = other.phoneNumber_;
      description_ = other.description_;
      isApproved_ = other.isApproved_;
      address_ = other.address_ != null ? other.address_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProviderMessage Clone() {
      return new ProviderMessage(this);
    }

    /// <summary>Field number for the "user" field.</summary>
    public const int UserFieldNumber = 1;
    private global::Networking.User.UserMessage user_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Networking.User.UserMessage User {
      get { return user_; }
      set {
        user_ = value;
      }
    }

    /// <summary>Field number for the "company_name" field.</summary>
    public const int CompanyNameFieldNumber = 2;
    private string companyName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CompanyName {
      get { return companyName_; }
      set {
        companyName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cvr" field.</summary>
    public const int CvrFieldNumber = 3;
    private int cvr_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Cvr {
      get { return cvr_; }
      set {
        cvr_ = value;
      }
    }

    /// <summary>Field number for the "phone_number" field.</summary>
    public const int PhoneNumberFieldNumber = 4;
    private string phoneNumber_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string PhoneNumber {
      get { return phoneNumber_; }
      set {
        phoneNumber_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "description" field.</summary>
    public const int DescriptionFieldNumber = 5;
    private string description_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Description {
      get { return description_; }
      set {
        description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "is_approved" field.</summary>
    public const int IsApprovedFieldNumber = 6;
    private bool isApproved_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsApproved {
      get { return isApproved_; }
      set {
        isApproved_ = value;
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 7;
    private global::Networking.Address.AddressMessage address_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Networking.Address.AddressMessage Address {
      get { return address_; }
      set {
        address_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProviderMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProviderMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(User, other.User)) return false;
      if (CompanyName != other.CompanyName) return false;
      if (Cvr != other.Cvr) return false;
      if (PhoneNumber != other.PhoneNumber) return false;
      if (Description != other.Description) return false;
      if (IsApproved != other.IsApproved) return false;
      if (!object.Equals(Address, other.Address)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (user_ != null) hash ^= User.GetHashCode();
      if (CompanyName.Length != 0) hash ^= CompanyName.GetHashCode();
      if (Cvr != 0) hash ^= Cvr.GetHashCode();
      if (PhoneNumber.Length != 0) hash ^= PhoneNumber.GetHashCode();
      if (Description.Length != 0) hash ^= Description.GetHashCode();
      if (IsApproved != false) hash ^= IsApproved.GetHashCode();
      if (address_ != null) hash ^= Address.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (user_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(User);
      }
      if (CompanyName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CompanyName);
      }
      if (Cvr != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Cvr);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PhoneNumber);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Description);
      }
      if (IsApproved != false) {
        output.WriteRawTag(48);
        output.WriteBool(IsApproved);
      }
      if (address_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(Address);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (user_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(User);
      }
      if (CompanyName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CompanyName);
      }
      if (Cvr != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Cvr);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PhoneNumber);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Description);
      }
      if (IsApproved != false) {
        output.WriteRawTag(48);
        output.WriteBool(IsApproved);
      }
      if (address_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(Address);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (user_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(User);
      }
      if (CompanyName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CompanyName);
      }
      if (Cvr != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Cvr);
      }
      if (PhoneNumber.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PhoneNumber);
      }
      if (Description.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
      }
      if (IsApproved != false) {
        size += 1 + 1;
      }
      if (address_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Address);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProviderMessage other) {
      if (other == null) {
        return;
      }
      if (other.user_ != null) {
        if (user_ == null) {
          User = new global::Networking.User.UserMessage();
        }
        User.MergeFrom(other.User);
      }
      if (other.CompanyName.Length != 0) {
        CompanyName = other.CompanyName;
      }
      if (other.Cvr != 0) {
        Cvr = other.Cvr;
      }
      if (other.PhoneNumber.Length != 0) {
        PhoneNumber = other.PhoneNumber;
      }
      if (other.Description.Length != 0) {
        Description = other.Description;
      }
      if (other.IsApproved != false) {
        IsApproved = other.IsApproved;
      }
      if (other.address_ != null) {
        if (address_ == null) {
          Address = new global::Networking.Address.AddressMessage();
        }
        Address.MergeFrom(other.Address);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (user_ == null) {
              User = new global::Networking.User.UserMessage();
            }
            input.ReadMessage(User);
            break;
          }
          case 18: {
            CompanyName = input.ReadString();
            break;
          }
          case 24: {
            Cvr = input.ReadInt32();
            break;
          }
          case 34: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 42: {
            Description = input.ReadString();
            break;
          }
          case 48: {
            IsApproved = input.ReadBool();
            break;
          }
          case 58: {
            if (address_ == null) {
              Address = new global::Networking.Address.AddressMessage();
            }
            input.ReadMessage(Address);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (user_ == null) {
              User = new global::Networking.User.UserMessage();
            }
            input.ReadMessage(User);
            break;
          }
          case 18: {
            CompanyName = input.ReadString();
            break;
          }
          case 24: {
            Cvr = input.ReadInt32();
            break;
          }
          case 34: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 42: {
            Description = input.ReadString();
            break;
          }
          case 48: {
            IsApproved = input.ReadBool();
            break;
          }
          case 58: {
            if (address_ == null) {
              Address = new global::Networking.Address.AddressMessage();
            }
            input.ReadMessage(Address);
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class ProvidersMessage : pb::IMessage<ProvidersMessage>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProvidersMessage> _parser = new pb::MessageParser<ProvidersMessage>(() => new ProvidersMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProvidersMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Networking.Provider.ProviderReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProvidersMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProvidersMessage(ProvidersMessage other) : this() {
      providers_ = other.providers_.Clone();
      pageInfo_ = other.pageInfo_ != null ? other.pageInfo_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProvidersMessage Clone() {
      return new ProvidersMessage(this);
    }

    /// <summary>Field number for the "providers" field.</summary>
    public const int ProvidersFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Networking.Provider.ProviderMessage> _repeated_providers_codec
        = pb::FieldCodec.ForMessage(10, global::Networking.Provider.ProviderMessage.Parser);
    private readonly pbc::RepeatedField<global::Networking.Provider.ProviderMessage> providers_ = new pbc::RepeatedField<global::Networking.Provider.ProviderMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Networking.Provider.ProviderMessage> Providers {
      get { return providers_; }
    }

    /// <summary>Field number for the "pageInfo" field.</summary>
    public const int PageInfoFieldNumber = 2;
    private global::Networking.Page.PageMessage pageInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Networking.Page.PageMessage PageInfo {
      get { return pageInfo_; }
      set {
        pageInfo_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProvidersMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProvidersMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!providers_.Equals(other.providers_)) return false;
      if (!object.Equals(PageInfo, other.PageInfo)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= providers_.GetHashCode();
      if (pageInfo_ != null) hash ^= PageInfo.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      providers_.WriteTo(output, _repeated_providers_codec);
      if (pageInfo_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(PageInfo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      providers_.WriteTo(ref output, _repeated_providers_codec);
      if (pageInfo_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(PageInfo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += providers_.CalculateSize(_repeated_providers_codec);
      if (pageInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PageInfo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProvidersMessage other) {
      if (other == null) {
        return;
      }
      providers_.Add(other.providers_);
      if (other.pageInfo_ != null) {
        if (pageInfo_ == null) {
          PageInfo = new global::Networking.Page.PageMessage();
        }
        PageInfo.MergeFrom(other.PageInfo);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            providers_.AddEntriesFrom(input, _repeated_providers_codec);
            break;
          }
          case 18: {
            if (pageInfo_ == null) {
              PageInfo = new global::Networking.Page.PageMessage();
            }
            input.ReadMessage(PageInfo);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            providers_.AddEntriesFrom(ref input, _repeated_providers_codec);
            break;
          }
          case 18: {
            if (pageInfo_ == null) {
              PageInfo = new global::Networking.Page.PageMessage();
            }
            input.ReadMessage(PageInfo);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code