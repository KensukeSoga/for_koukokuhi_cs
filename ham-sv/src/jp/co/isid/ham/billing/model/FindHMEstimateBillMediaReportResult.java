package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM���Ϗ��A�������׏��A�������쐬(�}��)��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateBillMediaReportResult extends AbstractServiceResult {

    /** ���Ϗ��A�������׏��o�͏�� */
    private FindHMEstimateMediaReportResult _hmEstimateMedia = null;
    /** �������o�͏�� */
    private FindHMBillMediaReportResult _hmBillMedia = null;

    /**
     * ���Ϗ��A�������׏��o�͏����擾����
     * @return FindHMEstimateMediaReportResult ���ψČ�/���ϖ���
     */
    public FindHMEstimateMediaReportResult getHMEstimateMedia() {
        return _hmEstimateMedia;
    }

    /**
     * ���Ϗ��A�������׏��o�͏���ݒ肷��
     * @param vo FindHMEstimateMediaReportResult ���ψČ�/���ϖ���
     */
    public void setHMEstimateMedia(FindHMEstimateMediaReportResult result) {
        _hmEstimateMedia = result;
    }

    /**
     * �������o�͏����擾����
     * @return FindHMBillMediaReportResult �������o�͏��
     */
    public FindHMBillMediaReportResult getHMBillMedia() {
        return _hmBillMedia;
    }

    /**
     * �������o�͏���ݒ肷��
     * @param vo FindHMBillMediaReportResult �������o�͏��
     */
    public void setHMBillMedia(FindHMBillMediaReportResult result) {
        _hmBillMedia = result;
    }

}
