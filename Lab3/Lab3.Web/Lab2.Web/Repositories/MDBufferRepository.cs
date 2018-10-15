using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Web.Repositories
{
    public class MDBufferRepository
    {
        public MDBufferRepository()
        {
            ResetBuffer();
        }

        public uint A { get; private set; }
        public uint B { get; private set; }
        public uint C { get; private set; }
        public uint D { get; private set; }

        public void ResetBuffer()
        {
            A = 0x67452301;
            B = 0xEFCDAB89;
            C = 0x98BADCFE;
            D = 0x10325476;
        }

        public override string ToString()
        {
            return (BitConverter.ToString(BitConverter.GetBytes(A))
                + BitConverter.ToString(BitConverter.GetBytes(B))
                + BitConverter.ToString(BitConverter.GetBytes(C))
                + BitConverter.ToString(BitConverter.GetBytes(D))).Replace("-", string.Empty);
        }

        public uint this[int i, int cycleNumber]
        {
            get
            {
                switch (cycleNumber)
                {
                    case 0:
                        {
                            switch (i)
                            {
                                case 0: return A;
                                case 1: return B;
                                case 2: return C;
                                case 3: return D;
                                default: throw new Exception("Unknown buffer index.");
                            }
                        }
                    case 1:
                        {
                            switch (i)
                            {
                                case 0: return D;
                                case 1: return A;
                                case 2: return B;
                                case 3: return C;
                                default: throw new Exception("Unknown buffer index.");
                            }
                        }
                    case 2:
                        {
                            switch (i)
                            {
                                case 0: return C;
                                case 1: return D;
                                case 2: return A;
                                case 3: return B;
                                default: throw new Exception("Unknown buffer index.");
                            }
                        }
                    case 3:
                        {
                            switch (i)
                            {
                                case 0: return B;
                                case 1: return C;
                                case 2: return D;
                                case 3: return A;
                                default: throw new Exception("Unknown buffer index.");
                            }
                        }
                    default: throw new Exception("Unknown cycle number.");
                }
            }            
        }

        public uint this[int cycleNumber]
        {
            set
            {
                switch (cycleNumber)
                {
                    case 0: A = value; break;
                    case 1: D = value; break;
                    case 2: C = value; break;
                    case 3: B = value; break;
                    default: throw new Exception("Unknown cycle number.");
                }
            }
        }
        
        public static MDBufferRepository operator +(MDBufferRepository buffer1, MDBufferRepository buffer2)
        {
            return new MDBufferRepository
            {
                A = buffer1.A + buffer2.A,
                B = buffer1.B + buffer2.B,
                C = buffer1.C + buffer2.C,
                D = buffer1.D + buffer2.D
            };
        }

        public MDBufferRepository Clone()
        {
            return new MDBufferRepository { A = this.A, B = this.B, C = this.C, D = this.D };
        }
    }
}