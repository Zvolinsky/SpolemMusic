using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class LabelsService
    {
        private AppDBContext _context;

        public LabelsService(AppDBContext context) { _context = context; }

        public List<Label> GetLabels()
        {
            var labels = _context.Labels.ToList();
            return labels;
        }

        public Label AddLabel(LabelDTO label)
        {
            var _label = new Label()
            {
                Name = label.Name,
            };
            _context.Labels.Add(_label);
            _context.SaveChanges();

            return _label;
        }

        public void UpdateLabel(LabelDTO label, int id)
        {
            var _label = _context.Labels.FirstOrDefault(c => c.Id == id);
            if (_label != null)
            {
                _label.Name = label.Name;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteLabel(int id)
        {
            var _label = _context.Labels.FirstOrDefault(c => c.Id == id);
            if (_label != null)
            {
                _context.Labels.Remove(_label);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
