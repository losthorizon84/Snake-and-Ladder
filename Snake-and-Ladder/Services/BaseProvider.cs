using Snake_and_Ladder.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Snake_and_Ladder.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Snake_and_Ladder.Services
{
    public abstract class BaseProvider<T> : IGenericProvider<T>
        where T : IDentifiable
    {
        protected readonly ILogger<BaseProvider<T>> _logger;
        protected IList<T> _repository;

        public BaseProvider(ILogger<BaseProvider<T>> logger)
        {
            _repository = new List<T>();
        }

        public void Add(T t)
        {
            _repository.Add(t);
        }

        public T FindSingle(Expression<Func<T, bool>> criteria)
        {
            return _repository.FirstOrDefault(criteria.Compile());
        }

    }
}
