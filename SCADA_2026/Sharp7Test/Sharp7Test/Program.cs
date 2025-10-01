using System;

class Program
{
    static void Main()
    {
        var plc = new PLCService("192.168.1.5");
        var db = new DatabaseService("server=localhost;user=scada;password=scada_pass;database=scada_demo;");

        Console.WriteLine("✅ Connected to PLC + DB");
        Console.WriteLine("Press '1'=ON, '0'=OFF, 'q'=quit.");

        int toggleCount = 0;
        DateTime windowStart = DateTime.Now;

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'q') break;

            if (key.KeyChar == '1')
            {
                plc.WriteMotorOn(true);
                db.LogMotorState("ON");
                Console.WriteLine("MotorOn = TRUE");
                toggleCount++;
            }

            if (key.KeyChar == '0')
            {
                plc.WriteMotorOn(false);
                db.LogMotorState("OFF");
                Console.WriteLine("MotorOn = FALSE");
                toggleCount++;
            }

            // Check alarm rule
            if ((DateTime.Now - windowStart).TotalSeconds > 60)
            {
                toggleCount = 0;
                windowStart = DateTime.Now;
            }
            if (toggleCount > 5)
            {
                db.LogAlarm("Motor chatter detected");
                Console.WriteLine("⚠️ Alarm: Motor chatter detected");
                toggleCount = 0;
                windowStart = DateTime.Now;
            }
        }

        plc.Disconnect();
    }
}
