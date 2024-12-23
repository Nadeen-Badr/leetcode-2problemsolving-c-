# Write your MySQL query statement below
select a.machine_id,ROUND(AVG(b.timestamp-a.timestamp),3) as processing_time
from Activity a
join Activity b
on a.process_id=b.process_id
and a.machine_id=b.machine_id
and a.timestamp<b.timestamp
group by a.machine_id;
-----------
--date diff and join the same table
Select w.id
from Weather w, Weather w0
Where DATEDIFF(w.recordDate,w0.recordDate)=1 and w.temperature>w0.temperature;

-----------
--unique id nulls will be shown
Select p.unique_id , e.name
from Employees as e
left join EmployeeUNI as p
on p.id=e.id
----------
SELECT tweet_id FROM Tweets WHERE length(content)>15;
----------
