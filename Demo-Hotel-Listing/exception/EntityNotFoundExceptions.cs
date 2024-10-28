//namespace Demo_Hotel_Listing.exception
//{
//    [Serializable]
//    public class EntityNotFoundException : Exception
//    {
//        public string Entity { get; }
//        public long Id { get; }

//        public EntityNotFoundException(string entity)
//            : base($"No entity '{entity}' found.")
//        {
//            Entity = entity;
//            Id = 0;
//        }

//        public EntityNotFoundException(string entity, long id)
//            : base($"No entity '{entity}' found with id {id}.")
//        {
//            Entity = entity;
//            Id = id;
//        }
//    }
//}
