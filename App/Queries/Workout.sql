select * from qikFit.Workouts

delete from qikFit.Workouts where id in(51,52,53,54)


select * from qikFit.UserWorkouts

select w.Name, wt.Name WorkoutType, l.Name Location, ag.Range, g.Name Gender, r.Range Radius, w.FitnessLevel, w.Date
from qikFit.Workouts w
	inner join qikFit.Locations l on w.LocationId = l.Id
	inner join qikFit.WorkoutType wt on w.WorkoutTypeId = wt.Id
	inner join qikFit.AgeGroups ag on w.AgeGroupId = ag.Id
	inner join qikFit.Gender g on w.GenderId = g.Id
	inner join qikFit.Radius r on w.RadiusId = r.Id


select w.Name, wt.Name WorkoutType, l.Name Location, ag.Range, g.Name Gender, r.Range Radius, w.FitnessLevel, w.Date, u.FirstName
from qikFit.Workouts w
	inner join qikFit.Locations l on w.LocationId = l.Id
	inner join qikFit.WorkoutType wt on w.WorkoutTypeId = wt.Id
	inner join qikFit.AgeGroups ag on w.AgeGroupId = ag.Id
	inner join qikFit.Gender g on w.GenderId = g.Id
	inner join qikFit.Radius r on w.RadiusId = r.Id
	inner join qikFit.UserWorkouts uw on uw.WorkoutId = w.Id
	inner join qikFit.Users u on u.Id = uw.UserId