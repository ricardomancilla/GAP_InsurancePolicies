import { Component, Input, OnInit, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Code, Policy } from '@app/_models';
import { PolicyService } from '@app/_services/policy.service';

@Component({ templateUrl: 'policy.add.component.html' })
export class PolicyAddComponent implements OnInit {
    @Input() coverageCodeList: Code[];
    @Input() riskTypeList: Code[];
    @Input() data: Policy;
    onAdd = new EventEmitter();

    addPolicyForm: FormGroup;
    submitted = false;
    loading = false;

    constructor(
        private policyService: PolicyService,
        private formBuilder: FormBuilder,
        public activeModal: NgbActiveModal
    ) {
    }

    ngOnInit() {
        this.addPolicyForm = this.formBuilder.group({
            PolicyID: [this.data ? this.data.PolicyID : 0],
            Name: [this.data ? this.data.Name : '', [Validators.required, Validators.maxLength(20)]],
            Description: [this.data ? this.data.Description : '', [Validators.required, Validators.maxLength(300)]],
            CoverageTypeID: [this.data ? this.data.CoverageTypeID : '', Validators.required],
            CoverageType: [''],
            RiskTypeID: [this.data ? this.data.RiskTypeID : '', Validators.required],
            RiskType: [''],
            CoveragePercentage: [this.data ? this.data.CoveragePercentage : '', Validators.required],
            CoverageTerm: [this.data ? this.data.CoverageTerm : '', Validators.required],
            Price: [this.data ? this.data.Price : '', [Validators.required, Validators.min(1)]]
        });
    }

    get form() { return this.addPolicyForm.controls; }

    onSubmit() {
        this.submitted = true;

        if (this.addPolicyForm.invalid) {
            return;
        }

        this.loading = true;

        var dataPolicy = {
            PolicyID: this.data ? this.data.PolicyID : 0,
            Name: this.form.Name.value,
            Description: this.form.Description.value,
            CoveragePercentage: this.form.CoveragePercentage.value,
            CoverageTerm: this.form.CoverageTerm.value,
            CoverageTypeID: this.form.CoverageTypeID.value,
            Price: this.form.Price.value,
            RiskTypeID: this.form.RiskTypeID.value
        };

        if (this.data && this.data.PolicyID > 0) {
            this.policyService.editPolicy(dataPolicy)
                .subscribe(
                    () => {
                        this.onAdd.emit({ type: "success", message: "The Policy was updated successfully." })
                        this.activeModal.close('Ok click');
                    },
                    error => {
                        this.onAdd.emit({ type: "danger", message: `Error updating the Policy: ${error}` })
                        this.loading = false;
                    });
        } else {
            this.policyService.addPolicy(dataPolicy)
                .subscribe(
                    () => {
                        this.onAdd.emit({ type: "success", message: "The Policy was added successfully." })
                        this.activeModal.close('Ok click');
                    },
                    error => {
                        this.onAdd.emit({ type: "danger", message: `Error adding the Policy: ${error}` })
                        this.loading = false;
                    });
        }
    }
}