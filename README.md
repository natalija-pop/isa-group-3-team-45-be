# isa-group-3-team-45
Repozitorijum namenjen realizaciji projekta iz predmata ISA na FTN-u 23/24

Komande za kreiranje sema u bazi podataka:
CREATE SCHEMA "isa";

Pokretanje migracija:
Add-Migration -Name Init -Context DatabaseContext -Project ISAProject -StartupProject API
Update-Database -Context DatabaseContext -Project ISAProject -StartupProject API

Test podaci i model class dijagram se nalaze u folderu TestData.
Test podaci su u obliku txt fajla u kojima su skripte za insert podataka u bazu.
