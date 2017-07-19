package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu16Skukjk;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �����������VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu16SkukjkVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu16SkukjkVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu16SkukjkVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu16Skukjk.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu16Skukjk.THSKGYCD, val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu16Skukjk.SEQNO);
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu16Skukjk.SEQNO, val);
    }

    /**
     * ��S���r�d�p�m�n���擾����
     *
     * @return ��S���r�d�p�m�n
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu16Skukjk.TRTNTSEQNO);
    }

    /**
     * ��S���r�d�p�m�n��ݒ肷��
     *
     * @param val ��S���r�d�p�m�n
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu16Skukjk.TRTNTSEQNO, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu16Skukjk.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu16Skukjk.ENDYMD, val);
    }

    /**
     * �����o�^�������擾����
     *
     * @return �����o�^����
     */
    @XmlElement(required = true, nillable = true)
    public Date getINSDATE() {
        return (Date) get(RepaVbjaMeu16Skukjk.INSDATE);
    }

    /**
     * �����o�^������ݒ肷��
     *
     * @param val �����o�^����
     */
    public void setINSDATE(Date val) {
        set(RepaVbjaMeu16Skukjk.INSDATE, val);
    }

    /**
     * �����o�^�S���҃R�[�h���擾����
     *
     * @return �����o�^�S���҃R�[�h
     */
    public String getINSTNTCD() {
        return (String) get(RepaVbjaMeu16Skukjk.INSTNTCD);
    }

    /**
     * �����o�^�S���҃R�[�h��ݒ肷��
     *
     * @param val �����o�^�S���҃R�[�h
     */
    public void setINSTNTCD(String val) {
        set(RepaVbjaMeu16Skukjk.INSTNTCD, val);
    }

    /**
     * �����o�^�A�v���h�c���擾����
     *
     * @return �����o�^�A�v���h�c
     */
    public String getINSAPLID() {
        return (String) get(RepaVbjaMeu16Skukjk.INSAPLID);
    }

    /**
     * �����o�^�A�v���h�c��ݒ肷��
     *
     * @param val �����o�^�A�v���h�c
     */
    public void setINSAPLID(String val) {
        set(RepaVbjaMeu16Skukjk.INSAPLID, val);
    }

    /**
     * �ŏI�X�V�������擾����
     *
     * @return �ŏI�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDAPLDATE() {
        return (Date) get(RepaVbjaMeu16Skukjk.UPDAPLDATE);
    }

    /**
     * �ŏI�X�V������ݒ肷��
     *
     * @param val �ŏI�X�V����
     */
    public void setUPDAPLDATE(Date val) {
        set(RepaVbjaMeu16Skukjk.UPDAPLDATE, val);
    }

    /**
     * �ŏI�X�V�S���҃R�[�h���擾����
     *
     * @return �ŏI�X�V�S���҃R�[�h
     */
    public String getUPDTNTCD() {
        return (String) get(RepaVbjaMeu16Skukjk.UPDTNTCD);
    }

    /**
     * �ŏI�X�V�S���҃R�[�h��ݒ肷��
     *
     * @param val �ŏI�X�V�S���҃R�[�h
     */
    public void setUPDTNTCD(String val) {
        set(RepaVbjaMeu16Skukjk.UPDTNTCD, val);
    }

    /**
     * �ŏI�X�V�I�����C���A�v���h�c���擾����
     *
     * @return �ŏI�X�V�I�����C���A�v���h�c
     */
    public String getUPDONLAPLID() {
        return (String) get(RepaVbjaMeu16Skukjk.UPDONLAPLID);
    }

    /**
     * �ŏI�X�V�I�����C���A�v���h�c��ݒ肷��
     *
     * @param val �ŏI�X�V�I�����C���A�v���h�c
     */
    public void setUPDONLAPLID(String val) {
        set(RepaVbjaMeu16Skukjk.UPDONLAPLID, val);
    }

    /**
     * �ŏI�X�V�o�b�`�A�v���h�c���擾����
     *
     * @return �ŏI�X�V�o�b�`�A�v���h�c
     */
    public String getUPDBATAPLID() {
        return (String) get(RepaVbjaMeu16Skukjk.UPDBATAPLID);
    }

    /**
     * �ŏI�X�V�o�b�`�A�v���h�c��ݒ肷��
     *
     * @param val �ŏI�X�V�o�b�`�A�v���h�c
     */
    public void setUPDBATAPLID(String val) {
        set(RepaVbjaMeu16Skukjk.UPDBATAPLID, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu16Skukjk.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu16Skukjk.STARTYMD, val);
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu16Skukjk.SNSTNT);
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param val �\���҃R�[�h
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu16Skukjk.SNSTNT, val);
    }

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return �c�Ə��R�[�h
     */
    public String getEGSYOCD() {
        return (String) get(RepaVbjaMeu16Skukjk.EGSYOCD);
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     *
     * @param val �c�Ə��R�[�h
     */
    public void setEGSYOCD(String val) {
        set(RepaVbjaMeu16Skukjk.EGSYOCD, val);
    }

    /**
     * �M�p�����X�V�N�������擾����
     *
     * @return �M�p�����X�V�N����
     */
    public String getSINUPDYMD() {
        return (String) get(RepaVbjaMeu16Skukjk.SINUPDYMD);
    }

    /**
     * �M�p�����X�V�N������ݒ肷��
     *
     * @param val �M�p�����X�V�N����
     */
    public void setSINUPDYMD(String val) {
        set(RepaVbjaMeu16Skukjk.SINUPDYMD, val);
    }

    /**
     * �M�p�R�[�h���擾����
     *
     * @return �M�p�R�[�h
     */
    public String getSINCD() {
        return (String) get(RepaVbjaMeu16Skukjk.SINCD);
    }

    /**
     * �M�p�R�[�h��ݒ肷��
     *
     * @param val �M�p�R�[�h
     */
    public void setSINCD(String val) {
        set(RepaVbjaMeu16Skukjk.SINCD, val);
    }

    /**
     * �M�p���x�z���擾����
     *
     * @return �M�p���x�z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSINGND() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.SINGND);
    }

    /**
     * �M�p���x�z��ݒ肷��
     *
     * @param val �M�p���x�z
     */
    public void setSINGND(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.SINGND, val);
    }

    /**
     * ���������X�V�N�������擾����
     *
     * @return ���������X�V�N����
     */
    public String getSKUPDYMD() {
        return (String) get(RepaVbjaMeu16Skukjk.SKUPDYMD);
    }

    /**
     * ���������X�V�N������ݒ肷��
     *
     * @param val ���������X�V�N����
     */
    public void setSKUPDYMD(String val) {
        set(RepaVbjaMeu16Skukjk.SKUPDYMD, val);
    }

    /**
     * �v�Z�S�����擾����
     *
     * @return �v�Z�S��
     */
    public String getSKKSNTNT() {
        return (String) get(RepaVbjaMeu16Skukjk.SKKSNTNT);
    }

    /**
     * �v�Z�S����ݒ肷��
     *
     * @param val �v�Z�S��
     */
    public void setSKKSNTNT(String val) {
        set(RepaVbjaMeu16Skukjk.SKKSNTNT, val);
    }

    /**
     * �������������擾����
     *
     * @return ����������
     */
    public String getSKSMDAY() {
        return (String) get(RepaVbjaMeu16Skukjk.SKSMDAY);
    }

    /**
     * ������������ݒ肷��
     *
     * @param val ����������
     */
    public void setSKSMDAY(String val) {
        set(RepaVbjaMeu16Skukjk.SKSMDAY, val);
    }

    /**
     * �������͓����擾����
     *
     * @return �������͓�
     */
    public String getSKTDKDAY() {
        return (String) get(RepaVbjaMeu16Skukjk.SKTDKDAY);
    }

    /**
     * �������͓���ݒ肷��
     *
     * @param val �������͓�
     */
    public void setSKTDKDAY(String val) {
        set(RepaVbjaMeu16Skukjk.SKTDKDAY, val);
    }

    /**
     * ���������s�����擾����
     *
     * @return ���������s��
     */
    public String getSKHKDAY() {
        return (String) get(RepaVbjaMeu16Skukjk.SKHKDAY);
    }

    /**
     * ���������s����ݒ肷��
     *
     * @param val ���������s��
     */
    public void setSKHKDAY(String val) {
        set(RepaVbjaMeu16Skukjk.SKHKDAY, val);
    }

    /**
     * ��������X�V�N�������擾����
     *
     * @return ��������X�V�N����
     */
    public String getKSUPDYMD() {
        return (String) get(RepaVbjaMeu16Skukjk.KSUPDYMD);
    }

    /**
     * ��������X�V�N������ݒ肷��
     *
     * @param val ��������X�V�N����
     */
    public void setKSUPDYMD(String val) {
        set(RepaVbjaMeu16Skukjk.KSUPDYMD, val);
    }

    /**
     * ����S�����擾����
     *
     * @return ����S��
     */
    public String getKSTNT() {
        return (String) get(RepaVbjaMeu16Skukjk.KSTNT);
    }

    /**
     * ����S����ݒ肷��
     *
     * @param val ����S��
     */
    public void setKSTNT(String val) {
        set(RepaVbjaMeu16Skukjk.KSTNT, val);
    }

    /**
     * ����\������擾����
     *
     * @return ����\���
     */
    public String getKSYOTEIDAY() {
        return (String) get(RepaVbjaMeu16Skukjk.KSYOTEIDAY);
    }

    /**
     * ����\�����ݒ肷��
     *
     * @param val ����\���
     */
    public void setKSYOTEIDAY(String val) {
        set(RepaVbjaMeu16Skukjk.KSYOTEIDAY, val);
    }

    /**
     * �萔�����S���擾����
     *
     * @return �萔�����S
     */
    public String getKSTSURYO() {
        return (String) get(RepaVbjaMeu16Skukjk.KSTSURYO);
    }

    /**
     * �萔�����S��ݒ肷��
     *
     * @param val �萔�����S
     */
    public void setKSTSURYO(String val) {
        set(RepaVbjaMeu16Skukjk.KSTSURYO, val);
    }

    /**
     * �����敪�i�P�j���擾����
     *
     * @return �����敪�i�P�j
     */
    public String getBNKTKBN1() {
        return (String) get(RepaVbjaMeu16Skukjk.BNKTKBN1);
    }

    /**
     * �����敪�i�P�j��ݒ肷��
     *
     * @param val �����敪�i�P�j
     */
    public void setBNKTKBN1(String val) {
        set(RepaVbjaMeu16Skukjk.BNKTKBN1, val);
    }

    /**
     * �D�揇�ʁi�P�D�P�j���擾����
     *
     * @return �D�揇�ʁi�P�D�P�j
     */
    public String getYSN11() {
        return (String) get(RepaVbjaMeu16Skukjk.YSN11);
    }

    /**
     * �D�揇�ʁi�P�D�P�j��ݒ肷��
     *
     * @param val �D�揇�ʁi�P�D�P�j
     */
    public void setYSN11(String val) {
        set(RepaVbjaMeu16Skukjk.YSN11, val);
    }

    /**
     * ����z�i�P�D�P�j���擾����
     *
     * @return ����z�i�P�D�P�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJGNGAK11() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.JGNGAK11);
    }

    /**
     * ����z�i�P�D�P�j��ݒ肷��
     *
     * @param val ����z�i�P�D�P�j
     */
    public void setJGNGAK11(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.JGNGAK11, val);
    }

    /**
     * ����i�P�D�P�j���擾����
     *
     * @return ����i�P�D�P�j
     */
    public String getKNS11() {
        return (String) get(RepaVbjaMeu16Skukjk.KNS11);
    }

    /**
     * ����i�P�D�P�j��ݒ肷��
     *
     * @param val ����i�P�D�P�j
     */
    public void setKNS11(String val) {
        set(RepaVbjaMeu16Skukjk.KNS11, val);
    }

    /**
     * �T�C�g�i�P�D�P�j���擾����
     *
     * @return �T�C�g�i�P�D�P�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSITE11() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.SITE11);
    }

    /**
     * �T�C�g�i�P�D�P�j��ݒ肷��
     *
     * @param val �T�C�g�i�P�D�P�j
     */
    public void setSITE11(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.SITE11, val);
    }

    /**
     * �D�揇�ʁi�P�D�Q�j���擾����
     *
     * @return �D�揇�ʁi�P�D�Q�j
     */
    public String getYSN12() {
        return (String) get(RepaVbjaMeu16Skukjk.YSN12);
    }

    /**
     * �D�揇�ʁi�P�D�Q�j��ݒ肷��
     *
     * @param val �D�揇�ʁi�P�D�Q�j
     */
    public void setYSN12(String val) {
        set(RepaVbjaMeu16Skukjk.YSN12, val);
    }

    /**
     * ����z�i�P�D�Q�j���擾����
     *
     * @return ����z�i�P�D�Q�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJGNGAK12() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.JGNGAK12);
    }

    /**
     * ����z�i�P�D�Q�j��ݒ肷��
     *
     * @param val ����z�i�P�D�Q�j
     */
    public void setJGNGAK12(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.JGNGAK12, val);
    }

    /**
     * ����i�P�D�Q�j���擾����
     *
     * @return ����i�P�D�Q�j
     */
    public String getKNS12() {
        return (String) get(RepaVbjaMeu16Skukjk.KNS12);
    }

    /**
     * ����i�P�D�Q�j��ݒ肷��
     *
     * @param val ����i�P�D�Q�j
     */
    public void setKNS12(String val) {
        set(RepaVbjaMeu16Skukjk.KNS12, val);
    }

    /**
     * �T�C�g�i�P�D�Q�j���擾����
     *
     * @return �T�C�g�i�P�D�Q�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSITE12() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.SITE12);
    }

    /**
     * �T�C�g�i�P�D�Q�j��ݒ肷��
     *
     * @param val �T�C�g�i�P�D�Q�j
     */
    public void setSITE12(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.SITE12, val);
    }

    /**
     * �䗦�i�P�D�P�j���擾����
     *
     * @return �䗦�i�P�D�P�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHRT11() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.HRT11);
    }

    /**
     * �䗦�i�P�D�P�j��ݒ肷��
     *
     * @param val �䗦�i�P�D�P�j
     */
    public void setHRT11(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.HRT11, val);
    }

    /**
     * �䗦�i�P�D�Q�j���擾����
     *
     * @return �䗦�i�P�D�Q�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHRT12() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.HRT12);
    }

    /**
     * �䗦�i�P�D�Q�j��ݒ肷��
     *
     * @param val �䗦�i�P�D�Q�j
     */
    public void setHRT12(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.HRT12, val);
    }

    /**
     * �����敪�i�Q�j���擾����
     *
     * @return �����敪�i�Q�j
     */
    public String getBNKTKBN2() {
        return (String) get(RepaVbjaMeu16Skukjk.BNKTKBN2);
    }

    /**
     * �����敪�i�Q�j��ݒ肷��
     *
     * @param val �����敪�i�Q�j
     */
    public void setBNKTKBN2(String val) {
        set(RepaVbjaMeu16Skukjk.BNKTKBN2, val);
    }

    /**
     * �D�揇�ʁi�Q�D�P�j���擾����
     *
     * @return �D�揇�ʁi�Q�D�P�j
     */
    public String getYSN21() {
        return (String) get(RepaVbjaMeu16Skukjk.YSN21);
    }

    /**
     * �D�揇�ʁi�Q�D�P�j��ݒ肷��
     *
     * @param val �D�揇�ʁi�Q�D�P�j
     */
    public void setYSN21(String val) {
        set(RepaVbjaMeu16Skukjk.YSN21, val);
    }

    /**
     * ����z�i�Q�D�P�j���擾����
     *
     * @return ����z�i�Q�D�P�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJGNGAK21() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.JGNGAK21);
    }

    /**
     * ����z�i�Q�D�P�j��ݒ肷��
     *
     * @param val ����z�i�Q�D�P�j
     */
    public void setJGNGAK21(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.JGNGAK21, val);
    }

    /**
     * ����i�Q�D�P�j���擾����
     *
     * @return ����i�Q�D�P�j
     */
    public String getKNS21() {
        return (String) get(RepaVbjaMeu16Skukjk.KNS21);
    }

    /**
     * ����i�Q�D�P�j��ݒ肷��
     *
     * @param val ����i�Q�D�P�j
     */
    public void setKNS21(String val) {
        set(RepaVbjaMeu16Skukjk.KNS21, val);
    }

    /**
     * �T�C�g�i�Q�D�P�j���擾����
     *
     * @return �T�C�g�i�Q�D�P�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSITE21() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.SITE21);
    }

    /**
     * �T�C�g�i�Q�D�P�j��ݒ肷��
     *
     * @param val �T�C�g�i�Q�D�P�j
     */
    public void setSITE21(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.SITE21, val);
    }

    /**
     * �D�揇�ʁi�Q�D�Q�j���擾����
     *
     * @return �D�揇�ʁi�Q�D�Q�j
     */
    public String getYSN22() {
        return (String) get(RepaVbjaMeu16Skukjk.YSN22);
    }

    /**
     * �D�揇�ʁi�Q�D�Q�j��ݒ肷��
     *
     * @param val �D�揇�ʁi�Q�D�Q�j
     */
    public void setYSN22(String val) {
        set(RepaVbjaMeu16Skukjk.YSN22, val);
    }

    /**
     * ����z�i�Q�D�Q�j���擾����
     *
     * @return ����z�i�Q�D�Q�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJGNGAK22() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.JGNGAK22);
    }

    /**
     * ����z�i�Q�D�Q�j��ݒ肷��
     *
     * @param val ����z�i�Q�D�Q�j
     */
    public void setJGNGAK22(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.JGNGAK22, val);
    }

    /**
     * ����i�Q�D�Q�j���擾����
     *
     * @return ����i�Q�D�Q�j
     */
    public String getKNS22() {
        return (String) get(RepaVbjaMeu16Skukjk.KNS22);
    }

    /**
     * ����i�Q�D�Q�j��ݒ肷��
     *
     * @param val ����i�Q�D�Q�j
     */
    public void setKNS22(String val) {
        set(RepaVbjaMeu16Skukjk.KNS22, val);
    }

    /**
     * �T�C�g�i�Q�D�Q�j���擾����
     *
     * @return �T�C�g�i�Q�D�Q�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSITE22() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.SITE22);
    }

    /**
     * �T�C�g�i�Q�D�Q�j��ݒ肷��
     *
     * @param val �T�C�g�i�Q�D�Q�j
     */
    public void setSITE22(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.SITE22, val);
    }

    /**
     * �䗦�i�Q�D�P�j���擾����
     *
     * @return �䗦�i�Q�D�P�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHRT21() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.HRT21);
    }

    /**
     * �䗦�i�Q�D�P�j��ݒ肷��
     *
     * @param val �䗦�i�Q�D�P�j
     */
    public void setHRT21(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.HRT21, val);
    }

    /**
     * �䗦�i�Q�D�Q�j���擾����
     *
     * @return �䗦�i�Q�D�Q�j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHRT22() {
        return (BigDecimal) get(RepaVbjaMeu16Skukjk.HRT22);
    }

    /**
     * �䗦�i�Q�D�Q�j��ݒ肷��
     *
     * @param val �䗦�i�Q�D�Q�j
     */
    public void setHRT22(BigDecimal val) {
        set(RepaVbjaMeu16Skukjk.HRT22, val);
    }

    /**
     * �X�֔ԍ����擾����
     *
     * @return �X�֔ԍ�
     */
    public String getPOST() {
        return (String) get(RepaVbjaMeu16Skukjk.POST);
    }

    /**
     * �X�֔ԍ���ݒ肷��
     *
     * @param val �X�֔ԍ�
     */
    public void setPOST(String val) {
        set(RepaVbjaMeu16Skukjk.POST, val);
    }

    /**
     * �Z�����擾����
     *
     * @return �Z��
     */
    public String getADDRESS() {
        return (String) get(RepaVbjaMeu16Skukjk.ADDRESS);
    }

    /**
     * �Z����ݒ肷��
     *
     * @param val �Z��
     */
    public void setADDRESS(String val) {
        set(RepaVbjaMeu16Skukjk.ADDRESS, val);
    }

    /**
     * ���������擾����
     *
     * @return ������
     */
    public String getBUSYO() {
        return (String) get(RepaVbjaMeu16Skukjk.BUSYO);
    }

    /**
     * ��������ݒ肷��
     *
     * @param val ������
     */
    public void setBUSYO(String val) {
        set(RepaVbjaMeu16Skukjk.BUSYO, val);
    }

    /**
     * �d�b�ԍ����擾����
     *
     * @return �d�b�ԍ�
     */
    public String getTEL() {
        return (String) get(RepaVbjaMeu16Skukjk.TEL);
    }

    /**
     * �d�b�ԍ���ݒ肷��
     *
     * @param val �d�b�ԍ�
     */
    public void setTEL(String val) {
        set(RepaVbjaMeu16Skukjk.TEL, val);
    }

    /**
     * �M�p�R�[�h�������擾����
     *
     * @return �M�p�R�[�h����
     */
    public String getSKIGEN() {
        return (String) get(RepaVbjaMeu16Skukjk.SKIGEN);
    }

    /**
     * �M�p�R�[�h������ݒ肷��
     *
     * @param val �M�p�R�[�h����
     */
    public void setSKIGEN(String val) {
        set(RepaVbjaMeu16Skukjk.SKIGEN, val);
    }

}
