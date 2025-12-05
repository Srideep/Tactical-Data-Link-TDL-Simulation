using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL
{
    class Program
    {
        public static void Main(string[] args)
        {
            RadarSystem radar = new RadarSystem();
            PilotDisplay cockpit = new PilotDisplay();
            Link16Crypto link16 = new Link16Crypto();
            MissionComputer missionComputer = new MissionComputer(link16, radar, cockpit);

            string raw_message = "Target Locked: MIG-29";
            missionComputer.ProcessOutgoingMessage(raw_message);
            // Timing Delays (in seconds)
            double SensorScan = 0.05;
            double MissionComputingProcessing = 0.20;
            double Encryption = 0.15;
            double RadioTransmission = 0.10;
            double WeaponActivation = 0.10;

            MovingTarget target = new MovingTarget(510);
            double totalLatency = SensorScan + MissionComputingProcessing + Encryption + RadioTransmission + WeaponActivation;
            missionComputer.ProcessOutgoingMessage(raw_message);
            double target_Position= target.GetPositionAtTime(totalLatency);
            double predictedPosition = 0.0 + (510 * totalLatency);
            double MissDistance = target_Position - predictedPosition;
            string FinalMissDistance = "Final Miss Distance: "+MissDistance+" meters";
            string MissionStatus;
            if (MissDistance < 10)
            {
                MissionStatus = "✅ SUCCESS: Target Destroyed";
            }
            else
            {
                MissionStatus = "❌ FAILURE: Target Missed";
            }
            List<string> lines = new List<string> { FinalMissDistance, MissionStatus };
            File.WriteAllLines("outputFile.txt", lines);
        }
    }
}
