using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleConsumer
{
    public class AreaRectangle
    {
        public class AreaRec
        {
            public int Length { get; set; }
            public int Width { get; set; }

            /// <summary>
            /// Empty constructor
            /// </summary>
            public AreaRec()
            {

            }

            /// <summary>
            /// Parameterized Constructor
            /// </summary>
            public AreaRec(int length, int width)
            {
                Length = length;
                Width = width;
            }

            // append with comma because when the length and width properties are sent, they are sent with a comma
            //check fiddler {"Length":2, "Width":3} i guess this is the json format
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Length);
                sb.Append(",");
                sb.Append(Width);
                return sb.ToString();
            }
        }
    }
}
