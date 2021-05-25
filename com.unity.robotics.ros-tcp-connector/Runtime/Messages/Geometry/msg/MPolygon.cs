//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geometry
{
    public class MPolygon : Message
    {
        public const string RosMessageName = "geometry_msgs/Polygon";

        // A specification of a polygon where the first and last points are assumed to be connected
        public MPoint32[] points;

        public MPolygon()
        {
            this.points = new MPoint32[0];
        }

        public MPolygon(MPoint32[] points)
        {
            this.points = points;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();

            listOfSerializations.Add(BitConverter.GetBytes(points.Length));
            foreach (var entry in points)
                listOfSerializations.Add(entry.Serialize());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {

            var pointsArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.points = new MPoint32[pointsArrayLength];
            for (var i = 0; i < pointsArrayLength; i++)
            {
                this.points[i] = new MPoint32();
                offset = this.points[i].Deserialize(data, offset);
            }

            return offset;
        }

        public override string ToString()
        {
            return "MPolygon: " +
            "\npoints: " + System.String.Join(", ", points.ToList());
        }
    }
}
