using Postgrest.Attributes;
using Postgrest.Models;

namespace MWorkDaily.Model;

[Table("DailyWork")]
public class DaliyModel : BaseModel
{
    [PrimaryKey("mainSeq", false)]
    public int ParentSeq {  get; set; }

    [Column("childSeq")]
    public int? ParentId { get; set; }   

    [Column("workDate")]
    public DateTime WorkDate { get; set; }

    [Column("workTitle")]
    public required string WorkTitle { get; set; }   

    [Column("workText")]
    public required string WorkText { get; set; }
}
