import { Component, OnInit, AfterViewInit } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

import { CodeService, PolicyService } from '@app/_services';
import { Code, Policy } from '@app/_models';
import { PolicyAddComponent } from './policy.add.component';
import { ConfirmationDialogService } from '@app/_helpers';
import { AssignPolicyComponent } from './assign-policy.component';

@Component({ templateUrl: 'policy.component.html' })
export class PolicyComponent implements OnInit, AfterViewInit {
    policyList: Policy[] = [];
    coverageCodeList: Code[] = [];
    riskTypeList: Code[] = [];

    isLoadingResults = true;

    columns: string[] = ['Name', 'Description', 'Coverage Percentage', 'Coverage Term', 'Price', 'Coverage Type', 'Risk Type', 'Options'];

    constructor(
        private confirmationDialogService: ConfirmationDialogService,
        private policyService: PolicyService,
        private codeService: CodeService,
        private modalService: NgbModal,
        private toastr: ToastrService,
        modalConfig: NgbModalConfig
    ) {
        modalConfig.backdrop = 'static';
        modalConfig.keyboard = true;
    }

    ngOnInit() { }

    ngAfterViewInit() {
        this.getPolicies();

        this.codeService.getCodes("COVERAGE")
            .subscribe(coverages => {
                this.coverageCodeList = coverages
            });

        this.codeService.getCodes("RISK")
            .subscribe(risks => {
                this.riskTypeList = risks
            });
    }

    add() {
        this.openModal(null);
    }

    edit(policy: Policy) {
        this.openModal(policy);
    }

    delete(policy: Policy) {
        this.confirmationDialogService.confirm('Please confirm..',
            'Do you really want to delete the Policy?', "Yes", "No")
            .then((result: boolean) => {
                if (result) {
                    this.isLoadingResults = true;
                    this.policyService.deletePolicy(policy.PolicyID)
                        .subscribe(
                            () => {
                                this.toastr.success('Policy successfully deleted.');
                                this.getPolicies();
                                this.isLoadingResults = false;
                            },
                            error => {
                                this.toastr.error(error);
                                this.isLoadingResults = false;
                            }
                        );
                }
            });
    }

    getPolicies() {
        this.policyService.getPolicies()
            .subscribe(
                policies => {
                    this.policyList = policies;
                },
                error => {
                    this.toastr.error('There was an error getting Policies');
                },
                () => {
                    this.isLoadingResults = false;
                }
            );
    }

    assignPolicy() {
        const modalRef = this.modalService.open(AssignPolicyComponent, { size: 'lg' });
        modalRef.componentInstance.policyList = this.policyList;
    }

    private openModal(data: any) {
        const modalRef = this.modalService.open(PolicyAddComponent);
        modalRef.componentInstance.coverageCodeList = this.coverageCodeList;
        modalRef.componentInstance.riskTypeList = this.riskTypeList;
        modalRef.componentInstance.data = data;
        modalRef.result.then(() => {
            this.getPolicies();
        });
    }
}