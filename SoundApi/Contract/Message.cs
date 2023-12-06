// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Contract
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Message : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Message GetRootAsMessage(ByteBuffer _bb) { return GetRootAsMessage(_bb, new Message()); }
  public static Message GetRootAsMessage(ByteBuffer _bb, Message obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Message __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Contract.MessageType TypeOfMessageType { get { int o = __p.__offset(4); return o != 0 ? (Contract.MessageType)__p.bb.Get(o + __p.bb_pos) : Contract.MessageType.NONE; } }
  public TTable? TypeOfMessage<TTable>() where TTable : struct, IFlatbufferObject { int o = __p.__offset(6); return o != 0 ? (TTable?)__p.__union<TTable>(o + __p.bb_pos) : null; }
  public Contract.SelectAllSound TypeOfMessageAsSelectAllSound() { return TypeOfMessage<Contract.SelectAllSound>().Value; }
  public Contract.SelectSoundIds TypeOfMessageAsSelectSoundIds() { return TypeOfMessage<Contract.SelectSoundIds>().Value; }
  public Contract.CreateSound TypeOfMessageAsCreateSound() { return TypeOfMessage<Contract.CreateSound>().Value; }
  public Contract.ModifySound TypeOfMessageAsModifySound() { return TypeOfMessage<Contract.ModifySound>().Value; }
  public Contract.DeleteSound TypeOfMessageAsDeleteSound() { return TypeOfMessage<Contract.DeleteSound>().Value; }
  public Contract.Sound TypeOfMessageAsSound() { return TypeOfMessage<Contract.Sound>().Value; }

  public static Offset<Contract.Message> CreateMessage(FlatBufferBuilder builder,
      Contract.MessageType type_of_message_type = Contract.MessageType.NONE,
      int type_of_messageOffset = 0) {
    builder.StartTable(2);
    Message.AddTypeOfMessage(builder, type_of_messageOffset);
    Message.AddTypeOfMessageType(builder, type_of_message_type);
    return Message.EndMessage(builder);
  }

  public static void StartMessage(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddTypeOfMessageType(FlatBufferBuilder builder, Contract.MessageType typeOfMessageType) { builder.AddByte(0, (byte)typeOfMessageType, 0); }
  public static void AddTypeOfMessage(FlatBufferBuilder builder, int typeOfMessageOffset) { builder.AddOffset(1, typeOfMessageOffset, 0); }
  public static Offset<Contract.Message> EndMessage(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    builder.Required(o, 6);  // type_of_message
    return new Offset<Contract.Message>(o);
  }
  public static void FinishMessageBuffer(FlatBufferBuilder builder, Offset<Contract.Message> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedMessageBuffer(FlatBufferBuilder builder, Offset<Contract.Message> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}