using Dapper.FluentMap.Mapping;
using Cybertron.Domain.Entities;

namespace Cybertron.Mappings.Maps
{
    public class DictMap : EntityMap<Dict>
    {
        public DictMap()
        {
            Map(x => x.Id).ToColumn("id");
            Map(x => x.Word).ToColumn("word");
            Map(x => x.Description).ToColumn("description");
            Map(x => x.IncludedAt).ToColumn("included_at");
            Map(x => x.AlteredAt).ToColumn("altered_at");
        }
    }
}
