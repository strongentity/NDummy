namespace NDummy
{
    public interface IGeneratorPredicate<in TProperty>
    {
        IGeneratorSpec GenerateWith(IFactory<TProperty> generator);
    }
}
