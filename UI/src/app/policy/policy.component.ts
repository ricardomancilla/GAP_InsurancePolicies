import { Component, OnInit, AfterViewInit } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

import { CodeService, PolicyService } from '@app/_services';
import { Code, Policy } from '@app/_models';
import { PolicyAddComponent } from './policy.add.component';

@Component({ templateUrl: 'policy.component.html' })
export class PolicyComponent implements OnInit, AfterViewInit {
    private _message = new Subject<string>();
    private _type: string;
    message: string;
    
    policyList: Policy[] = [];
    coverageCodeList: Code[] = [];
    riskTypeList: Code[] = [];

    isLoadingResults = true;

    columns: string[] = ['Name', 'Description', 'CoveragePercentage', 'CoverageTerm', 'Price', 'CoverageType', 'RiskType', 'Options'];

    constructor(
        private policyService: PolicyService,
        private codeService: CodeService,
        private modalService: NgbModal,
        modalConfig: NgbModalConfig
    ) {
        modalConfig.backdrop = 'static';
        modalConfig.keyboard = false;
    }

    ngOnInit() {
        this._message.subscribe((message) => this.message = message);
        this._message.pipe(debounceTime(5000)).subscribe(() => this.message = null);
    }

    ngAfterViewInit() {
        this.policyService.getPolicies()
            .subscribe(policies => {
                this.policyList = policies;
                this.isLoadingResults = false;
            });

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
        //Pedir confirmacion
        this.policyService.deletePolicy(policy.PolicyID)
            .subscribe();
    }

    private openModal(data: any){
        const modalRef = this.modalService.open(PolicyAddComponent);
        modalRef.componentInstance.coverageCodeList = this.coverageCodeList;
        modalRef.componentInstance.riskTypeList = this.riskTypeList;
        modalRef.componentInstance.data = data;
        modalRef.componentInstance.onAdd.subscribe((type: any, message: any) => {
            this._type = type;
            this._message.next(message);
        });
    }
}