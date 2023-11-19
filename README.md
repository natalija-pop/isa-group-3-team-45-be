# isa-group-3-team-45
Repozitorijum namenjen realizaciji projekta iz predmata ISA na FTN-u 23/24

Pokretanje migracija:
Add-Migration -Name Init -Context StakeholdersContext -Project ISAProject -StartupProject API
Update-Database -Context StakeholdersContext -Project ISAProject -StartupProject API
Add-Migration -Name Init -Context CompanyContext -Project ISAProject -StartupProject API
Update-Database -Context CompanyContext -Project ISAProject -StartupProject API

Test podaci i model class dijagram se nalaze u folderu TestData.
