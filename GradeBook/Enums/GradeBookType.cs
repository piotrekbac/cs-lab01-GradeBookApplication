using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Enums
{
    //Dodanie typu wyliczeniowego (Enum) "GradeBookType" z wartościami "Standard", "Ranked", "ESNU", "OneToFour", "SixPoint" oraz "Wsei".
    public enum GradeBookType
    {
        Standard,
        Ranked,
        ESNU, 
        OneToFour, 
        SixPoint,
        //Dodanie nowej wartości "Wsei" do typu wyliczeniowego "GradeBookType" - pomysł własnego GradeBook'a.
        Wsei
    }
}
