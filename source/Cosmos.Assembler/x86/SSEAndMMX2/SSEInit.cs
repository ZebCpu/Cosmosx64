﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Assembler.x86.SSE
{
    public class SSEInit
    {
        public SSEInit() { 
            new Comment("BEGIN - SSE Init");
            // CR4[bit 9]=1, CR4[bit 10]=1, CR0[bit 2]=0, CR0[bit 1]=1
            new Mov { DestinationReg = Registers.EAX, SourceReg = Registers.CR4 };
            new Or  { DestinationReg = Registers.EAX, SourceValue = 0x100 };
            new Mov { DestinationReg = Registers.CR4, SourceReg = Registers.EAX };
            new Mov { DestinationReg = Registers.EAX, SourceReg = Registers.CR4 };
            new Or  { DestinationReg = Registers.EAX, SourceValue = 0x200 };
            new Mov { DestinationReg = Registers.CR4, SourceReg = Registers.EAX };
            new Mov { DestinationReg = Registers.EAX, SourceReg = Registers.CR0 };
            new And { DestinationReg = Registers.EAX, SourceValue = 0xfffffffd };
            new Mov { DestinationReg = Registers.CR0, SourceReg = Registers.EAX };
            new Mov { DestinationReg = Registers.EAX, SourceReg = Registers.CR0 };

            new And { DestinationReg = Registers.EAX, SourceValue = 1 };
            new Mov { DestinationReg = Registers.CR0, SourceReg = Registers.EAX };
            new Comment("END - SSE Init");
        }
    }
}
