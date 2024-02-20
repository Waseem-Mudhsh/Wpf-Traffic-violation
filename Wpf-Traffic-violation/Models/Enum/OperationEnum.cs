using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.Models.Enum
{
  public  enum OperationEnum
    {
        [ValueString("Insert")]
        insertOperation=1,
        [ValueString("Edite")]
        editeOperation = 2,
        [ValueString("Delete")]
        DeleteOperation = 3,

    }
}
