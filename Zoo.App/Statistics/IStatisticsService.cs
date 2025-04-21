namespace Zoo.App.Statistics;

public interface IStatisticsService
{
    int GetTotalAnimalCount();
    
    int GetTotalEnclosureCount();

    int GetTotalHungryAnimalCount();
}