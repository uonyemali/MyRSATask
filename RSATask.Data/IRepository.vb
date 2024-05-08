Imports System.Linq

Public Interface IRepository(Of T As Class)
    Function GetAll() As IQueryable(Of T)
    Sub Add(entity As T)
    Sub Update(entity As T)
    Sub Delete(entity As T)
    Sub SaveChanges()
End Interface
