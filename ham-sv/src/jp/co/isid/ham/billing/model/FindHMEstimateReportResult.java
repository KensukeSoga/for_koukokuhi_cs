package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM���Ϗ��쐬��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateReportResult extends AbstractServiceResult {

    /** HM���Ϗ�(���ψČ�) */
    private List<FindHMEstimateItemVO> _estItem = null;
    /** HM���Ϗ�(���ϖ���) */
    private List<FindHMEstimateDetailVO> _estDetail = null;
    /** HM���Ϗ�(���ψČ�CR�����) */
    private List<FindHMEstimateCreateVO> _estCreate = null;
    /** HM���Ϗ�(�����捞) */
    private List<FindHMEstimateCreationCaptureVO> _estCapture = null;
    /** HM���Ϗ�(CR�����) */
    private List<FindHMEstimateCreationCrVO> _estCrCreation = null;
    /** ��Џ�� */
    private List<Mbj12CodeVO> _companyInfo = null;
    /** �d������Ōv�Z�敪 */
    private List<Mbj12CodeVO> _calKbn = null;
    /** �S�ЃR�[�h�}�X�^ */
    private List<RepaVbjaMeu29CcVO> _menu29 = null;
    /** �J�����_�[�}�X�^ */
    private List<Mbj21CalendarVO> _calendar = null;
    /** ��p���No�}�X�^ */
    private List<Mbj09HiyouVO> _hiyou = null;

    /**
     * HM���Ϗ�(���ψČ�)���擾����
     * @return List<FindHCEstimateListItemVO> HM���Ϗ�(���ψČ�)
     */
    public List<FindHMEstimateItemVO> getEstItem() {
        return _estItem;
    }

    /**
     * HM���Ϗ�(���ψČ�)��ݒ肷��
     * @param vo List<FindHCEstimateListItemVO> HM���Ϗ�(���ψČ�)
     */
    public void setEstItem(List<FindHMEstimateItemVO> vo) {
        _estItem = vo;
    }

    /**
     * HM���Ϗ�(���ϖ���)���擾����
     * @return List<FindEstimateDetailVO> HM���Ϗ�(���ϖ���)
     */
    public List<FindHMEstimateDetailVO> getEstDetail() {
        return _estDetail;
    }

    /**
     * HM���Ϗ�(���ϖ���)��ݒ肷��
     * @param vo List<FindEstimateDetailVO> HM���Ϗ�(���ϖ���)
     */
    public void setEstDetail(List<FindHMEstimateDetailVO> vo) {
        _estDetail = vo;
    }

    /**
     * HM���Ϗ�(���ψČ�CR�����)���擾����
     * @return List<FindHMEstimateCreateVO> HM���Ϗ�(���ψČ�CR�����)
     */
    public List<FindHMEstimateCreateVO> getEstCreate() {
        return _estCreate;
    }

    /**
     * HM���Ϗ�(���ψČ�CR�����)��ݒ肷��
     * @param vo List<FindHMEstimateCreateVO> HM���Ϗ�(���ψČ�CR�����)
     */
    public void setEstCreate(List<FindHMEstimateCreateVO> vo) {
        _estCreate = vo;
    }

    /**
     * HM���Ϗ�(�����捞)���擾����
     * @return List<FindHMEstimateCreationCaptureVO> HM���Ϗ�(�����捞)
     */
    public List<FindHMEstimateCreationCaptureVO> getEstCapture() {
        return _estCapture;
    }

    /**
     * HM���Ϗ�(�����捞)��ݒ肷��
     * @param vo List<FindHMEstimateCreationCaptureVO> HM���Ϗ�(�����捞)
     */
    public void setEstCapture(List<FindHMEstimateCreationCaptureVO> vo) {
        _estCapture = vo;
    }

    /**
     * HM���Ϗ�(CR�����)���擾����
     * @return List<FindHMEstimateCreationCrVO> HM���Ϗ�(CR�����)
     */
    public List<FindHMEstimateCreationCrVO> getEstCrCreateData() {
        return _estCrCreation;
    }

    /**
     * HM���Ϗ�(CR�����)��ݒ肷��
     * @param vo List<FindHMEstimateCreationCrVO> HM���Ϗ�(CR�����)
     */
    public void setEstCrCreateData(List<FindHMEstimateCreationCrVO> vo) {
        _estCrCreation = vo;
    }

    /**
     * ��Џ����擾����
     * @return List<Mbj12CodeVO> ��Џ��
     */
    public List<Mbj12CodeVO> getCompanyInfo() {
        return _companyInfo;
    }

    /**
     * ��Џ���ݒ肷��
     * @param vo List<Mbj12CodeVO> ��Џ��
     */
    public void setCompanyInfo(List<Mbj12CodeVO> vo) {
        _companyInfo = vo;
    }

    /**
     * �d������Ōv�Z�敪���擾����
     * @return List<Mbj12CodeVO> �d������Ōv�Z�敪
     */
    public List<Mbj12CodeVO> getCalKbn() {
        return _calKbn;
    }

    /**
     * �d������Ōv�Z�敪��ݒ肷��
     * @param vo List<Mbj12CodeVO> �d������Ōv�Z�敪
     */
    public void setCalKbn(List<Mbj12CodeVO> vo) {
        _calKbn = vo;
    }

    /**
     * �S�Ѓ}�X�^���擾����
     * @return List<RepaVbjaMeu29CcVO> �S�Ѓ}�X�^
     */
    public List<RepaVbjaMeu29CcVO> getMenu29() {
        return _menu29;
    }

    /**
     * �S�Ѓ}�X�^��ݒ肷��
     * @param vo List<RepaVbjaMeu29CcVO> �S�Ѓ}�X�^
     */
    public void setMenu29(List<RepaVbjaMeu29CcVO> vo) {
        _menu29 = vo;
    }

    /**
     * �J�����_�[�}�X�^���擾����
     * @return List<Mbj21CalendarVO> �J�����_�[�}�X�^
     */
    public List<Mbj21CalendarVO> getCalendar() {
        return _calendar;
    }

    /**
     * �J�����_�[�}�X�^��ݒ肷��
     * @param vo List<Mbj21CalendarVO> �J�����_�[�}�X�^
     */
    public void setCalendar(List<Mbj21CalendarVO> vo) {
        _calendar = vo;
    }

    /**
     * ��p���No�}�X�^���擾����
     * @return List<Mbj09HiyouVO> ��p���No�}�X�^
     */
    public List<Mbj09HiyouVO> getHiyou() {
        return _hiyou;
    }

    /**
     * ��p���No�}�X�^��ݒ肷��
     * @param vo List<Mbj09HiyouVO> ��p���No�}�X�^
     */
    public void setHiyou(List<Mbj09HiyouVO> vo) {
        _hiyou = vo;
    }

}
