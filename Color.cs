using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Color
    {
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        public UInt32 ColorCode { get; set; }
        public byte A
        {
            get
            {
                return (byte)((ColorCode >> 24) & 0xFF);
            }
            set
            {
                ColorCode = (UInt32)(value << 24) + ((ColorCode << 8) >> 8);
            }
        }
        public byte R
        {
            get
            {
                return (byte)((ColorCode >> 16) & 0xFF);
            }
            set
            {
                ColorCode = (UInt32)(value << 16) + ((ColorCode >> 24) << 24) + ((ColorCode % 0x10000));
            }
        }
        public byte G
        {
            get
            {
                return (byte)((ColorCode >> 8) & 0xFF);
            }
            set
            {
                ColorCode = (UInt32)(value << 8) + ((ColorCode >> 16) << 16) + ((ColorCode % 0x100));
            }
        }
        public byte B
        {
            get
            {
                return (byte)(ColorCode & 0xFF);
            }
            set
            {
                ColorCode = (UInt32)(value) + ((ColorCode >> 8) << 8);
            }
        }
        public override string ToString()
        {
            return $"Color\tA:{A}\tR:{R}\tG:{G}\tB:{B}";
        }


        public Color() { ColorCode = 0; }
        public Color(UInt32 colorCode) { ColorCode = colorCode; }
        public Color(byte R, byte G, byte B)
        {
            ColorCode = 0xFF000000 + (UInt32)(R << 16) + (UInt32)(G << 8) + B;
        }
        public Color(byte A, byte R, byte G, byte B)
        {
            ColorCode = (UInt32)A << 24 + (R << 16) + (G << 8) + B;
        }



        public override bool Equals(object obj)
        {
            object compareObj = obj as Color;
            if (compareObj == null)
                throw new ArgumentException("Wrong type!");
            else
                return this.ColorCode == ((Color)(compareObj)).ColorCode;
        }
    }
}
