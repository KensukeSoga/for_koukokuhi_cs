package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
//import jp.co.isid.ham.integ.tbl.Mfk02Jun;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̏󋵊Ǘ�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/17 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindMediaPlanVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �X�e�[�^�X
     */
    private BigDecimal _STATUS = null;

    /**
     * �L�����y�[��No�{�L�����y�[����
     */
    private String _CODENAME = null;


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMediaPlanVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindMediaPlanVO();
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj01MediaPlan.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj01MediaPlan.DCARCD, val);
    }

    /**
     * �L�����y�[���R�[�h���擾����
     *
     * @return �L�����y�[���R�[�h
     */
    public String getCAMPCD() {
        return (String) get(Tbj01MediaPlan.CAMPCD);
    }

    /**
     * �L�����y�[���R�[�h��ݒ肷��
     *
     * @param val �L�����y�[���R�[�h
     */
    public void setCAMPCD(String val) {
        set(Tbj01MediaPlan.CAMPCD, val);
    }

    /**
     * �}�̊Ǘ�No���擾����
     *
     * @return �}�̊Ǘ�No
     */
    @XmlElement(required = true)
    public BigDecimal getMEDIAPLANNO() {
        return (BigDecimal) get(Tbj01MediaPlan.MEDIAPLANNO);
    }

    /**
     * �}�̊Ǘ�No��ݒ肷��
     *
     * @param val �}�̊Ǘ�No
     */
    public void setMEDIAPLANNO(BigDecimal val) {
        set(Tbj01MediaPlan.MEDIAPLANNO, val);
    }

    /**
     * �}�̃\�[�g�����擾����
     *
     * @return �}�̃\�[�g��
     */
    @XmlElement(required = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj03Media.SORTNO);
    }

    /**
     * �}�̃\�[�g����ݒ肷��
     *
     * @param val �}�̃\�[�g��
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj03Media.SORTNO, val);
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj01MediaPlan.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj01MediaPlan.MEDIACD, val);
    }

    /**
     * �}�̂��擾����
     *
     * @return �}��
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * �}�̂�ݒ肷��
     *
     * @param val �}��
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * ��p�v��No���擾����
     *
     * @return ��p�v��No
     */
    public String getHIYOUNO() {
        return (String) get(Tbj01MediaPlan.HIYOUNO);
    }

    /**
     * ��p�v��No��ݒ肷��
     *
     * @param val ��p�v��No
     */
    public void setHIYOUNO(String val) {
        set(Tbj01MediaPlan.HIYOUNO, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj01MediaPlan.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj01MediaPlan.PHASE, val);
    }

    /**
     * �����擾����
     *
     * @return ��
     */
    public String getTERM() {
        return (String) get(Tbj01MediaPlan.TERM);
    }

    /**
     * ����ݒ肷��
     *
     * @param val ��
     */
    public void setTERM(String val) {
        set(Tbj01MediaPlan.TERM, val);
    }

    /**
     * �����擾����
     *
     * @return ��
     */
    @XmlElement(required = true)
    public Date getYOTEIYM() {
        return (Date) get(Tbj01MediaPlan.YOTEIYM);
    }

    /**
     * ����ݒ肷��
     *
     * @param val ��
     */
    public void setYOTEIYM(Date val) {
        set(Tbj01MediaPlan.YOTEIYM, val);
    }

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    @XmlElement(required = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj01MediaPlan.KIKANFROM);
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param val ���ԊJ�n
     */
    public void setKIKANFROM(Date val) {
        set(Tbj01MediaPlan.KIKANFROM, val);
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    @XmlElement(required = true)
    public Date getKIKANTO() {
        return (Date) get(Tbj01MediaPlan.KIKANTO);
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param val ���ԏI��
     */
    public void setKIKANTO(Date val) {
        set(Tbj01MediaPlan.KIKANTO, val);
    }

    /**
     * �\�Z���z���擾����
     *
     * @return �\�Z���z
     */
    @XmlElement(required = true)
    public BigDecimal getBUDGET() {
        return (BigDecimal) get(Tbj01MediaPlan.BUDGET);
    }

    /**
     * �\�Z���z��ݒ肷��
     *
     * @param val �\�Z���z
     */
    public void setBUDGET(BigDecimal val) {
        set(Tbj01MediaPlan.BUDGET, val);
    }

    /**
     * �\�Z���z(�V)���擾����
     *
     * @return �\�Z���z(�V)
     */
    @XmlElement(required = true)
    public BigDecimal getBUDGETHM() {
        return (BigDecimal) get(Tbj01MediaPlan.BUDGETHM);
    }

    /**
     * �\�Z���z(�V)��ݒ肷��
     *
     * @param val �\�Z���z(�V)
     */
    public void setBUDGETHM(BigDecimal val) {
        set(Tbj01MediaPlan.BUDGETHM, val);
    }

    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true)
    public BigDecimal getADJUSTMENT() {
        return (BigDecimal) get(Tbj01MediaPlan.ADJUSTMENT);
    }

    /**
     * �������z��ݒ肷��
     *
     * @param val �������z
     */
    public void setADJUSTMENT(BigDecimal val) {
        set(Tbj01MediaPlan.ADJUSTMENT, val);
    }

    /**
     * ���{���z���擾����
     *
     * @return ���{���z
     */
    @XmlElement(required = true)
    public BigDecimal getACTUAL() {
        return (BigDecimal) get(Tbj01MediaPlan.ACTUAL);
    }

    /**
     * ���{���z��ݒ肷��
     *
     * @param val ���{���z
     */
    public void setACTUAL(BigDecimal val) {
        set(Tbj01MediaPlan.ACTUAL, val);
    }

    /**
     * ���{���z(�V)���擾����
     *
     * @return ���{���z(�V)
     */
    @XmlElement(required = true)
    public BigDecimal getACTUALHM() {
        return (BigDecimal) get(Tbj01MediaPlan.ACTUALHM);
    }

    /**
     * ���{���z(�V)��ݒ肷��
     *
     * @param val ���{���z(�V)
     */
    public void setACTUALHM(BigDecimal val) {
        set(Tbj01MediaPlan.ACTUALHM, val);
    }

    /**
     * �\�����z���擾����
     *
     * @return �\�����z
     */
    @XmlElement(required = true)
    public BigDecimal getDIFAMT() {
        return (BigDecimal) get(Tbj01MediaPlan.DIFAMT);
    }

    /**
     * �\�����z��ݒ肷��
     *
     * @param val �\�����z
     */
    public void setDIFAMT(BigDecimal val) {
        set(Tbj01MediaPlan.DIFAMT, val);
    }

    /**
     * �\�����z(�V)���擾����
     *
     * @return �\�����z(�V)
     */
    @XmlElement(required = true)
    public BigDecimal getDIFAMTHM() {
        return (BigDecimal) get(Tbj01MediaPlan.DIFAMTHM);
    }

    /**
     * �\�����z(�V)��ݒ肷��
     *
     * @param val �\�����z(�V)
     */
    public void setDIFAMTHM(BigDecimal val) {
        set(Tbj01MediaPlan.DIFAMTHM, val);
    }

    /**
     * �g�l���F���擾����
     *
     * @return �g�l���F
     */
    public String getHMOK() {
        return (String) get(Tbj01MediaPlan.HMOK);
    }

    /**
     * �g�l���F��ݒ肷��
     *
     * @param val �g�l���F
     */
    public void setHMOK(String val) {
        set(Tbj01MediaPlan.HMOK, val);
    }

    /**
     * �}�̔������擾����
     *
     * @return �}�̔���
     */
    public String getBUYEROK() {
        return (String) get(Tbj01MediaPlan.BUYEROK);
    }

    /**
     * �}�̔�����ݒ肷��
     *
     * @param val �}�̔���
     */
    public void setBUYEROK(String val) {
        set(Tbj01MediaPlan.BUYEROK, val);
    }

    /**
     * �������擾����
     *
     * @return ����
     */
    public String getKENMEI() {
        return (String) get(Tbj01MediaPlan.KENMEI);
    }

    /**
     * ������ݒ肷��
     *
     * @param val ����
     */
    public void setKENMEI(String val) {
        set(Tbj01MediaPlan.KENMEI, val);
    }

    /**
     * ���L�������擾����
     *
     * @return ���L����
     */
    public String getMEMO() {
        return (String) get(Tbj01MediaPlan.MEMO);
    }

    /**
     * ���L������ݒ肷��
     *
     * @param val ���L����
     */
    public void setMEMO(String val) {
        set(Tbj01MediaPlan.MEMO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj01MediaPlan.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj01MediaPlan.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj01MediaPlan.CRTNM);
    }

    /**
     * �f�[�^�쐬�A�v����ݒ肷��
     *
     * @param val �f�[�^�쐬�A�v��
     */
    public void setCRTAPL(String val) {
        set(Tbj01MediaPlan.CRTAPL, val);
    }

    /**
     * �f�[�^�쐬�A�v�����擾����
     *
     * @return �f�[�^�쐬�A�v��
     */
    public String getCRTAPL() {
        return (String) get(Tbj01MediaPlan.CRTAPL);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj01MediaPlan.CRTNM, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj01MediaPlan.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj01MediaPlan.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj01MediaPlan.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj01MediaPlan.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj01MediaPlan.UPDNM);
    }

    /**
     * �f�[�^�X�VID��ݒ肷��
     *
     * @param val �f�[�^�X�VID
     */
    public void setUPDID(String val) {
        set(Tbj01MediaPlan.UPDID, val);
    }

    /**
     * �f�[�^�X�VID���擾����
     *
     * @return �f�[�^�X�VID
     */
    public String getUPDID() {
        return (String) get(Tbj01MediaPlan.UPDID);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj01MediaPlan.UPDNM, val);
    }

    /**
     * �X�e�[�^�X���擾���܂�
     * @return
     */
    public BigDecimal getSTATUS() {
        return _STATUS;
    }

    /**
     * �X�e�[�^�X��ݒ肵�܂�
     * @param val
     */
    public void setSTATUS(BigDecimal val) {
        _STATUS = val;
    }

    /**
     * �}�̌������擾����
     *
     * @return �}�̌���
     */
    public String getAUTHORITY() {
        return (String) get(Mbj10MediaSec.AUTHORITY);
    }

    /**
     * �}�̌�����ݒ肷��
     *
     * @param val �}�̌���
     */
    public void setAUTHORITY(String val) {
        set(Mbj10MediaSec.AUTHORITY, val);
    }

    /**
     * �L�����y�[��No�{�L�����y�[�������擾���܂�
     * @return
     */
    public String getCODENAME() {
        return _CODENAME;
    }

    /**
     *�L�����y�[��No�{�L�����y�[������ݒ肵�܂�
     * @param val
     */
    public void setCODENAME(String val) {
        _CODENAME = val;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj01MediaPlan.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj01MediaPlan.UPDAPL, val);
    }

    /**
     * �n��R�[�h���擾����
     *
     * @return �n��R�[�h
     */
    public String getKEIRETSUCD() {
        return (String) get(Mbj05Car.KEIRETSUCD);
    }

    /**
     * �n��R�[�h��ݒ肷��
     *
     * @param val �n��R�[�h
     */
    public void setKEIRETSUCD(String val) {
        set(Mbj05Car.KEIRETSUCD, val);
    }

    /**
     * �\�Z�o�^�t���O���擾����
     *
     * @return �\�Z�o�^�t���O
     */
    public String getBUDGETUPDFLG() {
        return (String) get(Tbj01MediaPlan.BUDGETUPDFLG);
    }

    /**
     * �\�Z�o�^�t���O��ݒ肷��
     *
     * @param val �\�Z�o�^�t���O
     */
    public void setBUDGETUPDFLG(String val) {
        set(Tbj01MediaPlan.BUDGETUPDFLG, val);
    }

}
