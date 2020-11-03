using Mediapipe;
using NUnit.Framework;

namespace Tests {
  public class PacketTest {
    #region #At
    [Test]
    public void At_ShouldReturnNewPacketWithTimestamp() {
      var timestamp = new Timestamp(1);
      var packet = new BoolPacket(true).At(timestamp);

      Assert.True(packet.GetValue());
      Assert.AreEqual(packet.Timestamp(), timestamp);

      var newTimestamp = new Timestamp(2);
      var newPacket = packet.At(newTimestamp);

      Assert.True(newPacket is BoolPacket);
      Assert.True(newPacket.GetValue());
      Assert.AreEqual(newPacket.Timestamp(), newTimestamp);

      Assert.True(packet.GetValue());
      Assert.AreEqual(packet.Timestamp(), timestamp);
    }
    #endregion

    #region #DebugString
    [Test]
    public void DebugString_ShouldReturnDebugString_When_InstantiatedWithDefaultConstructor() {
      var packet = new BoolPacket();

      Assert.AreEqual(packet.DebugString(), "mediapipe::Packet with timestamp: Timestamp::Unset() and no data");
    }
    #endregion

    #region #DebugTypeName
    [Test]
    public void DebugTypeName_ShouldReturnTypeName_When_ValueIsNotSet() {
      var packet = new BoolPacket();

      Assert.AreEqual(packet.DebugTypeName(), "{empty}");
    }
    #endregion

    #region #RegisteredTypeName
    [Test]
    public void RegisteredTypeName_ShouldReturnEmptyString_When_ValueIsNotSet() {
      var packet = new BoolPacket();

      Assert.AreEqual(packet.RegisteredTypeName(), "");
    }
    #endregion

    #region #ValidateAsProtoMessageLite
    [Test]
    public void ValidateAsProtoMessageLite_ShouldReturnInvalidArgument_When_ValueIsBool() {
      var packet = new BoolPacket(true);

      Assert.AreEqual(packet.ValidateAsProtoMessageLite().code, Status.StatusCode.InvalidArgument);
    }
    #endregion
  }
}
