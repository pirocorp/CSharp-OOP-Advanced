namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Container
{
    public interface IDependencyContainer
    {
        T Resolve<T>();

        void ResolveDependencies(object controller);

        void RegisterMapping<TFrom>(object to);
    }
}
