import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

import { DepartmentService } from '@app/_services/department.service';
import { CityService, PolicyService } from '@app/_services';

import { Department } from '@app/_models/department';
import { City } from '@app/_models/City';
import { Policy } from '@app/_models';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

@Component({ templateUrl: 'policy.component.html', styleUrls: ['policy.component.scss'] })
export class PolicyComponent implements OnInit, AfterViewInit {
    policyList: Policy[] = [];
    departmentList: Department[] = [];
    cityList: City[] = [];

    isLoadingResults = true;

    displayedColumns: string[] = ['name', 'description', 'coveragePercentaje', 'coverageTerm', 'price', 'coverageType', 'riskType', 'options'];

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private policyService: PolicyService,
        private departmentService: DepartmentService,
        private cityService: CityService
    ) { }

    // ngOnInit() {
    //     this.form = this.formBuilder.group({
    //         name: ['', Validators.required],
    //         description: ['', Validators.required],
    //         coveragePercentaje: ['', Validators.required],
    //         coverageTerm: ['', Validators.required],
    //         price: ['', Validators.required],
    //         coverageType: ['', Validators.required],
    //         riskType: ['', Validators.required]
    //     });
    // }

    ngAfterViewInit() {
        this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
        //this.paginator.change

        // this.policyService.getPolicies()
        //     .subscribe(policies => {
        //         this.policyList = policies,
        //         this.isLoadingResults = false
        //     });

        merge(this.sort.sortChange, this.paginator.page)
            .pipe(
                startWith({}),
                switchMap(() => {
                    this.isLoadingResults = true;
                    //return this.policyService.getPolicies();
                    var data: Policy[] = [
                        { Name: "Policy 1", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 2", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 3", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 4", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 5", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 6", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 7", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 8", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 9", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 10", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 11", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 12", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 13", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" },
                        { Name: "Policy 14", Description: "Description 2", CoveragePercentaje: 60, CoverageTerm: 12, Price: 1200000, CoverageTypeID: 1, CoverageType: "Earthquake", RiskTypeID: 1, RiskType: "Medium" },
                        { Name: "Policy 15", Description: "Description 1", CoveragePercentaje: 80, CoverageTerm: 12, Price: 1500000, CoverageTypeID: 1, CoverageType: "Loss", RiskTypeID: 1, RiskType: "Low" }
                    ];
                    return data;
                })
            ).subscribe(data => this.policyList = data);

        this.departmentService.getDepartments()
            .subscribe(departments => {
                this.departmentList = departments
            });

        this.cityService.getCities()
            .subscribe(cities => {
                this.cityList = cities
            });
    }
}