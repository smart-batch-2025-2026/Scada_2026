using Sharp7;

public class PLCService
{
    private S7Client client;

    public PLCService(string ip, int rack = 0, int slot = 1)
    {
        client = new S7Client();
        int result = client.ConnectTo(ip, rack, slot);
        if (result != 0)
            throw new Exception("PLC connection failed: " + client.ErrorText(result));
    }

    public void WriteMotorOn(bool state)
    {
        byte[] buffer = new byte[1];
        buffer[0] = state ? (byte)0x01 : (byte)0x00;
        int res = client.DBWrite(1, 0, 1, buffer);
        if (res != 0) throw new Exception("DBWrite error: " + client.ErrorText(res));
    }

    public bool ReadMotorOn()
    {
        byte[] buffer = new byte[1];
        int res = client.DBRead(1, 0, 1, buffer);
        if (res != 0) throw new Exception("DBRead error: " + client.ErrorText(res));
        return (buffer[0] & 0x01) != 0;
    }

    public void Disconnect() => client.Disconnect();
}
