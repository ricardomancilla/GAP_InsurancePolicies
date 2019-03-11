import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { DepartmentService } from '@app/_services/department.service';
import { CityService } from '@app/_services';

import { Department } from '@app/_models/department';
import { City } from '@app/_models/City';

@Component({ templateUrl: 'policy.component.html' })
export class PolicyComponent implements OnInit {
    departmentList: Department[] = [];
    cityList: City[] = [];

    form: FormGroup;
    loading = false;
    submitted = false;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private departmentService: DepartmentService,
        private cityService: CityService
    ) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });

        this.departmentService.getDepartments()
            .pipe()
            .subscribe(departments => {
                this.departmentList = departments
            });

        this.cityService.getCities()
            .pipe()
            .subscribe(cities => {
                this.cityList = cities
            });
    }
}