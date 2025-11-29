using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp2
{
    /// <summary>
    /// Общее хранилище тарифов, добавленных для сравнения.
    /// </summary>
    public class TariffComparisonStore
    {
        public ObservableCollection<View_1> SelectedTariffs { get; } = new ObservableCollection<View_1>();

        public void AddTariff(View_1 tariff)
        {
            if (tariff == null)
            {
                return;
            }

            if (!SelectedTariffs.Any(t => t.idTariffs == tariff.idTariffs))
            {
                SelectedTariffs.Add(tariff);
            }
        }

        public void RemoveTariff(View_1 tariff)
        {
            if (tariff == null)
            {
                return;
            }

            var existing = SelectedTariffs.FirstOrDefault(t => t.idTariffs == tariff.idTariffs);
            if (existing != null)
            {
                SelectedTariffs.Remove(existing);
            }
        }
    }
}

