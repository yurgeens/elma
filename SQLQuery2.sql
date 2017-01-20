select op.Name --AVG( 
from OperationResult as opr
join Operation as op ON op.Id = Opr.OperationID
GROUP  BY op.Name
having AVG(opr.ExecTimeMS) > 1000