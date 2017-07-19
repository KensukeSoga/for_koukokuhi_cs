package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.*;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* �c�ƍ�Ƒ䒠�̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2012/12/03 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")

public class FindAuthorityAccountBookResult extends AbstractServiceResult {

    /** �c�ƍ�Ƒ䒠�̏��擾 */
    private List<FindAuthorityAccountBookVO> _abo;

    /** �}�̏󋵊Ǘ��̏��擾 */
    private List<Tbj01MediaPlanVO> _mp;

    /** �L�����y�[���̏��擾 */
    private List<Tbj12CampaignVO> _cp;

    /** �}�̎�ʂ̎擾 */
    private List<FindMediaCategoryVO> _mct;

    /** �L�����y�[�����̎擾 */
    private List<FindAccountBookCampaignVO> _abcam;

    /** ���e��ڂ̏��擾 */
    private List<FindExpenseItemListVO> _ei;

    /** �X�y�[�X�̏��擾 */
    private List<FindSpaceVO> _space;

    /** ��ʍ��ڕ\���񐧌�}�X�^ */
    private List<Mbj37DisplayControlVO> _dc;

    /** �ꗗ�\���p�^�[�� */
    private List<Tbj30DisplayPatternVO> _dp;

    /** �Ԏ�̏��擾 */
    private List<CarListVO> _cl;

    /** �}�̂̏��擾 */
    private List<MediaListVO> _ml;

    /** �S�Ѓ}�X�^�̃R�[�h�}�X�^ */
    private List<RepaVbjaMeu29CcVO> _mc;

    /** �˗����� */
    private List<RepaVbjaMea10IrskVO> _od;

    /** �˗��� */
    private List<FindContactRequestVO> _fcr;

    /** �R�[�h�}�X�^ */
    private List<Mbj12CodeVO> _cd;

    /** �Z�L�����e�BInfo */
    private List<SecurityInfoVO> _secinfo;

    /** �@�\����Info */
    private List<FunctionControlInfoVO> _funcinfo;

    /** �X�y�[�X�}�X�^�l */
    private List<RepaVbjaMeu29CcVO> _spaceMaster;

    /** �V���}�X�^ */
    private List<Mbj47NewspaperVO> _newspaper;

    /** �˗���i�荞�ݏ�� */
    private List<FindContactRequestNarrowingVO> _fcrn;


    /**
     * �c�ƍ�Ƒ䒠VO���擾���܂�
     * @return _abo
     */
    public List<FindAuthorityAccountBookVO> getAuthorityAccountBook() {
        return _abo;
    }

    /**
     * �c�ƍ�Ƒ䒠VO��ݒ肵�܂�
     * @param _cam �Z�b�g���� _cam
     */
    public void setAuthorityAccountBook(List<FindAuthorityAccountBookVO> abo) {
        _abo = abo;
    }

    /**
     * �}�̏󋵊Ǘ�VO���擾
     * @return �}�̏󋵊Ǘ�
     */
    public List<Tbj01MediaPlanVO> getTbj01MediaPlan() {
        return _mp;
    }

    /**
     * �}�̏󋵊Ǘ�VO��ݒ�
     * @param mp
     */
    public void setTbj01MediaPlan(List<Tbj01MediaPlanVO> mp) {
        _mp = mp;
    }

    /**
     * �L�����y�[��VO���擾
     * @return �L�����y�[��
     */
    public List<Tbj12CampaignVO> getTbj12Campaign() {
        return _cp;
    }

    /**
     * �L�����y�[��VO��ݒ�
     * @param cp
     */
    public void setTbj12Campaign(List<Tbj12CampaignVO> cp) {
        _cp = cp;
    }

    /**
     * �}�̎��VO���擾���܂�
     * @return _mct
     */
    public List<FindMediaCategoryVO> getMediaCategory() {
        return _mct;
    }

    /**
     * �}�̎��VO��ݒ肵�܂�
     * @param _mct �Z�b�g���� _mct
     */
    public void setMediaCategory(List<FindMediaCategoryVO> mct) {
        _mct = mct;
    }

    /**
     * �L�����y�[��VO�̎擾
     *
     * @return _abcam
     */
    public List<FindAccountBookCampaignVO> getAccountBookCampaign()
    {
        return _abcam;
    }

    /**
     * �L�����y�[��VO�̐ݒ�
     * @param abcam �Z�b�g���� _abcam
     */
    public void setAccountBookCampaign(List<FindAccountBookCampaignVO> abcam)
    {
        _abcam = abcam;
    }

    /**
     * ���e���VO�̎擾
     *
     * @return _abcam
     */
    public List<FindExpenseItemListVO> getExpenseItemList()
    {
        return _ei;
    }

    /**
     * ���e���VO�̐ݒ�
     * @param abcam �Z�b�g���� _abcam
     */
    public void setExpenseItemList(List<FindExpenseItemListVO> ei)
    {
        _ei = ei;
    }

    /**
     * �X�y�[�X���擾
     * @return �X�y�[�X
     */
    public List<FindSpaceVO> getSpace() {
        return _space;
    }

    /**
     * �X�y�[�X��ݒ�
     * @param space
     */
    public void setSpace(List<FindSpaceVO> space) {
        _space = space;
    }

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
     * �Ԏ�ꗗ���擾����
     *
     * @return �Ԏ�ꗗ
     */
    public List<CarListVO> getCarList() {
        return _cl;
    }

    /**
     * �Ԏ�ꗗ��ݒ肷��
     *
     * @param dc �Ԏ�ꗗ
     */
    public void setCarList(List<CarListVO> cl) {
        _cl = cl;
    }

    /**
     * �}�̈ꗗ���擾����
     * @return �}�̈ꗗ
     */
    public List<MediaListVO> getMediaList() {
        return _ml;
    }

    /**
     * �}�̈ꗗ��ݒ肷��
     * @param ml �}�̈ꗗ
     */
    public void setMediaList(List<MediaListVO> ml) {
        _ml = ml;
    }

    /**
     * �˗�������擾����
     * @return �˗�����
     */
    public List<RepaVbjaMea10IrskVO> getRepaVbjaMea10Irsk() {
        return _od;
    }

    /**
     * �˗������ݒ肷��
     * @param od �˗�����
     */
    public void setRepaVbjaMea10Irsk(List<RepaVbjaMea10IrskVO> od) {
        _od = od;
    }

    /**
     * �˗�����擾����
     * @return �˗���
     */
    public List<FindContactRequestVO> getFindContactRequest() {
        return _fcr;
    }

    /**
     * �˗����ݒ肷��
     * @param fcr �˗���
     */
    public void setFindContactRequest(List<FindContactRequestVO> fcr) {
        _fcr = fcr;
    }

    /**
     * �S�Ѓ}�X�^�̃R�[�h�}�X�^���擾����
     * @return �S�Ѓ}�X�^�̃R�[�h�}�X�^
     */
    public List<RepaVbjaMeu29CcVO> getRepaVbjaMeu29Cc() {
        return _mc;
    }

    /**
     * �S�Ѓ}�X�^�̃R�[�h�}�X�^��ݒ肷��
     * @param mc �S�Ѓ}�X�^�̃R�[�h�}�X�^
     */
    public void setRepaVbjaMeu29Cc(List<RepaVbjaMeu29CcVO> mc) {
        _mc = mc;
    }

    /**
     * �R�[�h�}�X�^���擾����
     * @return �R�[�h�}�X�^
     */
    public List<Mbj12CodeVO> getMbj12Code() {
        return _cd;
    }

    /**
     * �R�[�h�}�X�^��ݒ肷��
     * @param cd �R�[�h�}�X�^
     */
    public void setMbj12Code(List<Mbj12CodeVO> cd) {
        _cd = cd;
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

    /**
     * �X�y�[�X�}�X�^VO���X�g���擾����
     * @return �X�y�[�X�}�X�^VO���X�g
     */
    public List<RepaVbjaMeu29CcVO>  getSpaceMasterList() {
        return _spaceMaster;
    }

    /**
     * �X�y�[�X�}�X�^VO���X�g��ݒ肷��
     * @param spaceMaster �X�y�[�X�}�X�^VO���X�g
     */
    public void setSpaceMasterList(List<RepaVbjaMeu29CcVO> spaceMaster) {
        _spaceMaster = spaceMaster;
    }

    /**
     * �V���}�X�^VO���X�g���擾����
     * @return �V���}�X�^VO���X�g
     */
    public List<Mbj47NewspaperVO> getNewspaper() {
        return _newspaper;
    }

    /**
     * �V���}�X�^VO���X�g��ݒ肷��
     * @param newspaper �V���}�X�^VO���X�g
     */
    public void setNewspaper(List<Mbj47NewspaperVO> newspaper) {
        _newspaper = newspaper;
    }

    /**
     * �˗���i�荞�ݏ����擾����
     * @return �˗���i�荞�ݏ��
     */
    public List<FindContactRequestNarrowingVO> getFCRNarrowing() {
        return _fcrn;
    }

    /**
     * �˗���i�荞�ݏ���ݒ肷��
     * @param fcrn �˗���i�荞�ݏ��
     */
    public void setFCRNarrowing(List<FindContactRequestNarrowingVO> fcrn) {
        _fcrn = fcrn;
    }


    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
