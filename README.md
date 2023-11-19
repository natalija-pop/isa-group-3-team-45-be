# isa-group-3-team-45
Repozitorijum namenjen realizaciji projekta iz predmata ISA na FTN-u 23/24

Pokretanje migracija:
Add-Migration -Name Init -Context StakeholdersContext -Project ISAProject -StartupProject API
Update-Database -Context StakeholdersContext -Project ISAProject -StartupProject API
Add-Migration -Name Init -Context CompanyContext -Project ISAProject -StartupProject API
Update-Database -Context CompanyContext -Project ISAProject -StartupProject API

Test podaci i model class dijagram se nalaze u folderu TestData.

Komande za kreiranje sema u bazi podataka:
CREATE SCHEMA "stakeholders";
CREATE SCHEMA "company";

Test podaci su u obliku txt fajla u kojima su skripte za insert podataka u bazu.
