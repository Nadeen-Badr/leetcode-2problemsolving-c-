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
--Q12/ multiple joins not that easy
# Write your MySQL query statement below
select
s.student_id
,s.student_name
,su.subject_name
,count(e.student_id) attended_exams
from Students s
cross join Subjects su
left join Examinations e
on s.student_id=e.student_id
and su.subject_name= e.subject_name
group by s.student_id,s.student_name,su.subject_name
order by s.student_id,s.student_name,su.subject_name;
---------------
-- this is faster
# Write your MySQL query statement below
select Students.student_id, Students.student_name, subjects.subject_name, count(Examinations.subject_name) as attended_exams
from Students
cross join subjects
left join Examinations
on Students.student_id=Examinations.student_id and subjects.subject_name=Examinations.subject_name
group by Students.student_name, subjects.subject_name, Students.student_id
order by Students.student_id , subjects.subject_name
---------------
--manger with at least 5 reports nice question about joining the same table
# Write your MySQL query statement below
select e.name from Employee e
join Employee c
on e.id=c.managerId
group by c.managerId
having count(*)>=5;