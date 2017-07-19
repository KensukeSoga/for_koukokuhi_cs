package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM���ψꗗ(���ψČ�)(����)�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillItemVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ϔԍ� */
    private static final String ESTIMATENO = "ESTIMATENO";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMBillItemVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHMBillItemVO();
    }

    /**
     * �t�F�C�Y���擾����
     * @return BigDecimal �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param val BigDecimal �t�F�C�Y
     */
    public void setPhase(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * �N����ݒ肷��
     * @param val Date �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     * @return BigDecimal ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj05EstimateItem.ESTSEQNO);
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     * @param val BigDecimal ���ψČ��Ǘ�NO
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj05EstimateItem.ESTSEQNO, val);
    }

    /**
     * ���ώ�ʂ��擾����
     * @return String ���ώ��
     */
    public String getESTIMATECLASS() {
        return (String) get(Tbj05EstimateItem.ESTIMATECLASS);
    }

    /**
     * ���ώ�ʂ�ݒ肷��
     * @param val String ���ώ��
     */
    public void setESTIMATECLASS(String val) {
        set(Tbj05EstimateItem.ESTIMATECLASS, val);
    }

    /**
     * ���ϓ��t���擾����
     * @return Date ���ϓ��t
     */
    @XmlElement(required = true, nillable = true)
    public Date getESTIMATEDATE() {
        return (Date) get(Tbj05EstimateItem.ESTIMATEDATE);
    }

    /**
     * ���ϓ��t��ݒ肷��
     * @param val Date ���ϓ��t
     */
    public void setESTIMATEDATE(Date val) {
        set(Tbj05EstimateItem.ESTIMATEDATE, val);
    }

    /**
     * �R�[�v�敪���擾����
     * @return String �R�[�v�敪
     */
    public String getCOOPKBN() {
        return (String) get(Tbj05EstimateItem.COOPKBN);
    }

    /**
     * �R�[�v�敪��ݒ肷��
     * @param val String �R�[�v�敪
     */
    public void setCOOPKBN(String val) {
        set(Tbj05EstimateItem.COOPKBN, val);
    }

    /**
     * ������擾����
     * @return String ����
     */
    public String getADDRESS() {
        return (String) get(Tbj05EstimateItem.ADDRESS);
    }

    /**
     * �����ݒ肷��
     * @param val String ����
     */
    public void setADDRESS(String val) {
        set(Tbj05EstimateItem.ADDRESS, val);
    }

    /**
     * �Č������擾����
     * @return String �Č���
     */
    public String getESTIMATENM() {
        return (String) get(Tbj05EstimateItem.ESTIMATENM);
    }

    /**
     * �Č�����ݒ肷��
     * @param val String �Č���
     */
    public void setESTIMATENM(String val) {
        set(Tbj05EstimateItem.ESTIMATENM, val);
    }

    /**
     * HC����R�[�h���擾����
     * @return String HC����R�[�h
     */
    public String getHCBUMONCD() {
        return (String) get(Tbj05EstimateItem.HCBUMONCD);
    }

    /**
     * HC����R�[�h��ݒ肷��
     * @param val String HC����R�[�h
     */
    public void setHCBUMONCD(String val) {
        set(Tbj05EstimateItem.HCBUMONCD, val);
    }

    /**
     * HC�S���Җ����擾����
     * @return String HC�S���Җ�
     */
    public String getHCUSERNM() {
        return (String) get(Tbj05EstimateItem.HCUSERNM);
    }

    /**
     * HC�S���Җ���ݒ肷��
     * @param val String HC�S���Җ�
     */
    public void setHCUSERNM(String val) {
        set(Tbj05EstimateItem.HCUSERNM, val);
    }

    /**
     * �[�i�������擾����
     * @return Date �[�i����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDLVDATE() {
        return (Date) get(Tbj05EstimateItem.DLVDATE);
    }

    /**
     * �[�i������ݒ肷��
     * @param val Date �[�i����
     */
    public void setDLVDATE(Date val) {
        set(Tbj05EstimateItem.DLVDATE, val);
    }

    /**
     * �l�������擾����
     * @return BigDecimal �l����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDISCOUNTRATE() {
        return (BigDecimal) get(Tbj05EstimateItem.DISCOUNTRATE);
    }

    /**
     * �l������ݒ肷��
     * @param val BigDecimal �l����
     */
    public void setDISCOUNTRATE(BigDecimal val) {
        set(Tbj05EstimateItem.DISCOUNTRATE, val);
    }

    /**
     * ���l���擾����
     * @return String ���l
     */
    public String getBIKO() {
        return (String) get(Tbj05EstimateItem.BIKO);
    }

    /**
     * ���l��ݒ肷��
     * @param val String ���l
     */
    public void setBIKO(String val) {
        set(Tbj05EstimateItem.BIKO, val);
    }

    /**
     * �ŏI���Ϗo�͓������擾����
     * @return Date �ŏI���Ϗo�͓���
     */
    @XmlElement(required = true, nillable = true)
    public Date getLASTOUTPUTDATE() {
        return (Date) get(Tbj05EstimateItem.LASTOUTPUTDATE);
    }

    /**
     * �ŏI���Ϗo�͓�����ݒ肷��
     * @param val Date �ŏI���Ϗo�͓���
     */
    public void setLASTOUTPUTDATE(Date val) {
        set(Tbj05EstimateItem.LASTOUTPUTDATE, val);
    }

    /**
     * �ŏI���Ϗo�͒S���҂��擾����
     * @return String �ŏI���Ϗo�͒S����
     */
    public String getLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.LASTOUTPUTNM);
    }

    /**
     * �ŏI���Ϗo�͒S���҂�ݒ肷��
     * @param val String �ŏI���Ϗo�͒S����
     */
    public void setLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.LASTOUTPUTNM, val);
    }

    /**
     * �o�̓t�@�C�������擾����
     * @return String �o�̓t�@�C����
     */
    public String getOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.OUTPUTFILENM);
    }

    /**
     * �o�̓t�@�C������ݒ肷��
     * @param val String �o�̓t�@�C����
     */
    public void setOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.OUTPUTFILENM, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     * @return String �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj05EstimateItem.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     * @param val String �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj05EstimateItem.DCARCD, val);
    }

    /**
     * �敪�R�[�h���擾����
     * @return String �敪�R�[�h
     */
    public String getDIVCD() {
        return (String) get(Tbj05EstimateItem.DIVCD);
    }

    /**
     * �敪�R�[�h��ݒ肷��
     * @param val String �敪�R�[�h
     */
    public void setDIVCD(String val) {
        set(Tbj05EstimateItem.DIVCD, val);
    }

    /**
     * �O���[�v�R�[�h���擾����
     * @return BigDecimal �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj05EstimateItem.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     * @param val BigDecimal �O���[�v�R�[�h
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj05EstimateItem.GROUPCD, val);
    }

    /**
     * ������O���[�v���擾����
     * @return String ������O���[�v
     */
    public String getHCBUMONCDBILL() {
        return (String) get(Tbj06EstimateDetail.HCBUMONCDBILL);
    }

    /**
     * ������O���[�v��ݒ肷��
     * @param val String ������O���[�v
     */
    public void setHCBUMONCDBILL(String val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILL, val);
    }

    /**
     * ������O���[�v�o�͏�SEQNO���擾����
     * @return BigDecimal ������O���[�v�o�͏�SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHCBUMONCDBILLSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);
    }

    /**
     * ������O���[�v�o�͏�SEQNO��ݒ肷��
     * @param val BigDecimal ������O���[�v�o�͏�SEQNO
     */
    public void setHCBUMONCDBILLSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     * @return Date �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj05EstimateItem.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     * @param val Date �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj05EstimateItem.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     * @return String �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj05EstimateItem.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     * @param val String �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj05EstimateItem.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     * @return String �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj05EstimateItem.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     * @param val String �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj05EstimateItem.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     * @return String �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj05EstimateItem.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     * @param val String �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj05EstimateItem.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     * @return Date �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj05EstimateItem.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     * @param val Date �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj05EstimateItem.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     * @return String �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj05EstimateItem.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     * @param val String �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj05EstimateItem.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     * @return String �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj05EstimateItem.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     * @param val String �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj05EstimateItem.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     * @return String �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj05EstimateItem.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     * @param val String �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj05EstimateItem.UPDID, val);
    }

    /**
     * �Ԏ햼���擾����
     * @return String �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     * @param val String �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �敪�����擾����
     * @return String �敪��
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * �敪����ݒ肷��
     * @param val String �敪��
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * �O���[�v�����擾����
     * @return String �O���[�v��
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * �O���[�v����ݒ肷��
     * @param val String �O���[�v��
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * �R�[�h�����擾����
     * @return String �R�[�h��
     */
    public String getCODENAME() {
        return (String) get(Mbj12Code.CODENAME);
    }

    /**
     * �R�[�h����ݒ肷��
     * @param val String �R�[�h��
     */
    public void setCODENAME(String val) {
        set(Mbj12Code.CODENAME, val);
    }

    /**
     * HC���喼���擾����
     * @return String HC���喼
     */
    public String getHCBUMONNM() {
        return (String) get(Mbj06HcBumon.HCBUMONNM);
    }

    /**
     * HC���喼��ݒ肷��
     * @param val String HC���喼
     */
    public void setHCBUMONNM(String val) {
        set(Mbj06HcBumon.HCBUMONNM, val);
    }

    /**
     * ���ϋ��z���擾����
     * @return BigDecimal ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMITUMORI() {
        return (BigDecimal) get(Tbj06EstimateDetail.MITUMORI);
    }

    /**
     * ���ϋ��z��ݒ肷��
     * @param val BigDecimal ���ϋ��z
     */
    public void setMITUMORI(BigDecimal val) {
        set(Tbj06EstimateDetail.MITUMORI, val);
    }

    /**
     * ���ϔԍ����擾����
     * @return String ���ϔԍ�
     */
    public String getEstimateNo() {
        return (String) get(ESTIMATENO);
    }

    /**
     * ���ϔԍ���ݒ肷��
     * @param val String ���ϔԍ�
     */
    public void setESTIMATENO(String val) {
        set(ESTIMATENO, val);
    }

    /**
     * �}�̃R�[�h���擾����
     * @return String �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj03MediaMng.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     * @param val String �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj03MediaMng.MEDIACD, val);
    }

}
