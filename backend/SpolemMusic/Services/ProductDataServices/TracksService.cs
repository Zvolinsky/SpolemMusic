using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class TracksService
    {
        private AppDBContext _context;

        public TracksService(AppDBContext context) { _context = context; }

        public List<Track> GetTracks()
        {
            var tracks = _context.Tracks.ToList();
            var artists = _context.Artists.ToList();
            return tracks;
        }

        public Track AddTrack(TrackDTO track)
        {
            var _track = new Track()
            {
                Title = track.Title,
                Length = track.Length,
                ProductId = track.ProductId,
            };
            _context.Tracks.Add(_track);
            _context.SaveChanges();

            return _track;
        }

        public void UpdateTrack(TrackDTO track, int id)
        {
            var _track = _context.Tracks.FirstOrDefault(c => c.Id == id);
            if (_track != null)
            {
                _track.Title = track.Title;
                _track.Length = track.Length;
                _track.ProductId = track.ProductId;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteTrack(int id)
        {
            var _track = _context.Tracks.FirstOrDefault(c => c.Id == id);
            if (_track != null)
            {
                _context.Tracks.Remove(_track);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
