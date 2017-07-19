package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj06HcBumonVO;
import jp.co.isid.ham.common.model.Mbj07HcUserVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC���ύ쐬��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateCreationResult extends AbstractServiceResult {

    /** ��ʍ��ڕ\���񐧌�}�X�^ */
    private List<Mbj37DisplayControlVO> _dc;

    /** �R�[�h�}�X�^ */
    private List<Mbj12CodeVO> _code;

    /** ����}�X�^ */
    private List<Mbj06HcBumonVO> _bumon;

    /** �J�����_�[�}�X�^ */
    private List<Mbj21CalendarVO> _calendar;

    /** �����O���[�v�}�X�^ */
    private List<Mbj26BillGroupVO> _group;

    /** HC���[�U�}�X�^ */
    private List<Mbj07HcUserVO> _user;

    /** HC���ψꗗ(���ψČ�) */
    private List<FindHCEstimateListItemVO> _item;

    /** �ύX�m�F�f�[�^(���쌴��) */
    private List<FindHCEstimateListDiffVO> _costDiffVoList;

    /** �ύX�m�F�f�[�^(�����) */
    private List<FindHCEstimateListDiffTotalVO> _totalDiffVoList;

    /** ���ϖ��� */
    private List<FindEstimateDetailVO> _estDetail;

    /** ���ψČ�CR����� */
    private List<FindEstimateCreateVO> _estCreate;

    /** HC���ύ쐬(�����捞) */
    private List<FindHCEstimateCreationCaptureVO> _capture;

    /** HC���i�}�X�^ */
    private List<FindHCProductVO> _product;

    /** CR�\�Z��ڃ}�X�^ */
    private List<Mbj16CrExpenceVO> _crExpence;

    /** CR����� */
    private List<FindHCEstimateCreationCrVO> _crCreateData;

    /** �S�ЃR�[�h�}�X�^ */
    private List<RepaVbjaMeu29CcVO> _menu29;

    /** �ꗗ�\���p�^�[�� */
    private List<Tbj30DisplayPatternVO> _dp;

    /** �Z�L�����e�BInfo */
    private List<SecurityInfoVO> _secinfo;

    /** �@�\����Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * ��ʍ��ڕ\���񐧌�}�X�^���擾����
     *
     * @return ��ʍ��ڕ\���񐧌�}�X�^
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^��ݒ肷��
     *
     * @param dc ��ʍ��ڕ\���񐧌�}�X�^
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /**
     * �R�[�h�}�X�^���擾����
     *
     * @return �R�[�h�}�X�^
     */
    public List<Mbj12CodeVO> getCode() {
        return _code;
    }

    /**
     * �R�[�h�}�X�^��ݒ肷��
     *
     * @param code �R�[�h�}�X�^
     */
    public void setCode(List<Mbj12CodeVO> code) {
        _code = code;
    }

    /**
     * ����}�X�^���擾����
     *
     * @return ����}�X�^
     */
    public List<Mbj06HcBumonVO> getBumon() {
        return _bumon;
    }

    /**
     * ����}�X�^��ݒ肷��
     *
     * @param bumon ����}�X�^
     */
    public void setBumon(List<Mbj06HcBumonVO> bumon) {
        _bumon = bumon;
    }

    /**
     * �J�����_�[�}�X�^���擾����
     *
     * @return �J�����_�[�}�X�^
     */
    public List<Mbj21CalendarVO> getCalendar() {
        return _calendar;
    }

    /**
     * �J�����_�[�}�X�^��ݒ肷��
     *
     * @param calendar �J�����_�[�}�X�^
     */
    public void setCalendar(List<Mbj21CalendarVO> calendar) {
        _calendar = calendar;
    }

    /**
     * �����O���[�v�}�X�^���擾����
     *
     * @return �����O���[�v�}�X�^
     */
    public List<Mbj26BillGroupVO> getGroup() {
        return _group;
    }

    /**
     * �����O���[�v�}�X�^��ݒ肷��
     *
     * @param group �����O���[�v�}�X�^
     */
    public void setGroup(List<Mbj26BillGroupVO> group) {
        _group = group;
    }

    /**
     * HC���[�U�}�X�^���擾����
     *
     * @return HC���[�U�}�X�^
     */
    public List<Mbj07HcUserVO> getUser() {
        return _user;
    }

    /**
     * HC���[�U�}�X�^���擾����
     *
     * @param user HC���[�U�}�X�^
     */
    public void setUser(List<Mbj07HcUserVO> user) {
        _user = user;
    }

    /**
     * HC���ψꗗ(���ψČ�)���擾����
     *
     * @return HC���ψꗗ(���ψČ�)
     */
    public List<FindHCEstimateListItemVO> getItem() {
        return _item;
    }

    /**
     * HC���ψꗗ(���ψČ�)��ݒ肷��
     *
     * @param item HC���ψꗗ(���ψČ�)
     */
    public void setItem(List<FindHCEstimateListItemVO> item) {
        _item = item;
    }

    /**
     *  �ύX�m�F�f�[�^(���쌴��)�擾VO���擾
     *
     * @return  �ύX�m�F�f�[�^(���쌴��)�擾VO
     */
    public List<FindHCEstimateListDiffVO> getCostDiffVoList() {
        return _costDiffVoList;
    }

    /**
     * �ύX�m�F�f�[�^(���쌴��)�擾VO��ݒ�
     *
     * @param costDiffVo �ύX�m�F�f�[�^(���쌴��)�擾VO
     */
    public void setCostDiffVoList(List<FindHCEstimateListDiffVO> costDiffVo) {
        _costDiffVoList = costDiffVo;
    }

    /**
     *  �ύX�m�F�f�[�^(�����)�擾VO���擾
     *
     * @return  �ύX�m�F�f�[�^(�����)�擾VO
     */
    public List<FindHCEstimateListDiffTotalVO> getTotalDiffVoList() {
        return _totalDiffVoList;
    }

    /**
     * �ύX�m�F�f�[�^(�����)�擾VO��ݒ�
     *
     * @param totalDiffVo �ύX�m�F�f�[�^(�����)�擾VO
     */
    public void setTotalDiffVoList(List<FindHCEstimateListDiffTotalVO> totalDiffVo) {
        _totalDiffVoList = totalDiffVo;
    }

    /**
     * ���ϖ��ׂ��擾����
     *
     * @return ���ϖ���
     */
    public List<FindEstimateDetailVO> getEstDetail() {
        return _estDetail;
    }

    /**
     * ���ϖ��ׂ�ݒ肷��
     *
     * @param estDetail ���ϖ���
     */
    public void setEstDetail(List<FindEstimateDetailVO> estDetail) {
        _estDetail = estDetail;
    }

    /**
     * ���ψČ�CR�������擾����
     *
     * @return ���ψČ�CR�����
     */
    public List<FindEstimateCreateVO> getEstCreate() {
        return _estCreate;
    }

    /**
     * ���ψČ�CR������ݒ肷��
     *
     * @param estCreate ���ψČ�CR�����
     */
    public void setEstCreate(List<FindEstimateCreateVO> estCreate) {
        _estCreate = estCreate;
    }

    /**
     * HC���ύ쐬(�����捞)���擾����
     *
     * @return HC���ύ쐬(�����捞)
     */
    public List<FindHCEstimateCreationCaptureVO> getCapture() {
        return _capture;
    }

    /**
     * HC���ύ쐬(�����捞)��ݒ肷��
     *
     * @param capture HC���ύ쐬(�����捞)
     */
    public void setCapture(List<FindHCEstimateCreationCaptureVO> capture) {
        _capture = capture;
    }

    /**
     * HC���i�}�X�^���擾����
     *
     * @return HC���i�}�X�^
     */
    public List<FindHCProductVO> getProduct() {
        return _product;
    }

    /**
     * HC���i�}�X�^��ݒ肷��
     *
     * @param product HC���i�}�X�^
     */
    public void setProduct(List<FindHCProductVO> product) {
        _product = product;
    }

    /**
     * CR�\�Z��ڃ}�X�^���擾����
     *
     * @return CR�\�Z��ڃ}�X�^
     */
    public List<Mbj16CrExpenceVO> getCrExpence() {
        return _crExpence;
    }

    /**
     * CR�\�Z��ڃ}�X�^��ݒ肷��
     *
     * @param crExpence CR�\�Z��ڃ}�X�^
     */
    public void setCrExpence(List<Mbj16CrExpenceVO> crExpence) {
        _crExpence = crExpence;
    }

    /**
     * CR�������擾����
     *
     * @return CR�����
     */
    public List<FindHCEstimateCreationCrVO> getCrCreateData() {
        return _crCreateData;
    }

    /**
     * CR������ݒ肷��
     *
     * @param crCreateData CR�����
     */
    public void setCrCreateData(List<FindHCEstimateCreationCrVO> crCreateData) {
        _crCreateData = crCreateData;
    }

    /**
     * �S�ЃR�[�h�}�X�^���擾����
     *
     * @return �S�ЃR�[�h�}�X�^
     */
    public List<RepaVbjaMeu29CcVO>  getMenu29() {
        return _menu29;
    }

    /**
     * �S�ЃR�[�h�}�X�^��ݒ肷��
     *
     * @param menu29 �S�ЃR�[�h�}�X�^
     */
    public void setMenu29(List<RepaVbjaMeu29CcVO> menu29) {
        _menu29 = menu29;
    }

    /**
     * �ꗗ�\���p�^�[�����擾����
     *
     * @return �ꗗ�\���p�^�[��
     */
    public List<Tbj30DisplayPatternVO> getDisplayPattern() {
        return _dp;
    }

    /**
     * �ꗗ�\���p�^�[����ݒ肷��
     *
     * @param dp �ꗗ�\���p�^�[��
     */
    public void setDisplayPattern(List<Tbj30DisplayPatternVO> dp) {
        _dp = dp;
    }

    /**
     * �Z�L�����e�BInfoVO���X�g���擾����
     * @return �Z�L�����e�BInfoVO���X�g
     */
    public List<SecurityInfoVO> getSecurityInfoVoList() {
        return _secinfo;
    }

    /**
     * �Z�L�����e�BInfoVO���X�g��ݒ肷��
     * @param secinfo �Z�L�����e�BInfoVO���X�g
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> secinfo) {
        _secinfo = secinfo;
    }

    /**
     * �@�\����InfoVO���X�g���擾����
     * @return �@�\����InfoVO���X�g
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * �@�\����InfoVO���X�g��ݒ肷��
     * @param secinfo �@�\����InfoVO���X�g
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
    }
}
