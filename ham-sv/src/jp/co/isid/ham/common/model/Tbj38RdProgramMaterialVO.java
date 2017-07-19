package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I�ԑg�f��VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj38RdProgramMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj38RdProgramMaterialVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj38RdProgramMaterialVO();
    }

    /**
     * ���W�I�ԑgSEQNO���擾����
     *
     * @return ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.RDSEQNO);
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     *
     * @param val ���W�I�ԑgSEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial.RDSEQNO, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    public String getYEARMONTH() {
        return (String) get(Tbj38RdProgramMaterial.YEARMONTH);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setYEARMONTH(String val) {
        set(Tbj38RdProgramMaterial.YEARMONTH, val);
    }

    /**
     * �gSEQNO���擾����
     *
     * @return �gSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getWAKUSEQ() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.WAKUSEQ);
    }

    /**
     * �gSEQNO��ݒ肷��
     *
     * @param val �gSEQNO
     */
    public void setWAKUSEQ(BigDecimal val) {
        set(Tbj38RdProgramMaterial.WAKUSEQ, val);
    }

    /**
     * �Y������1�����擾����
     *
     * @return �Y������1��
     */
    public String getDAY01() {
        return (String) get(Tbj38RdProgramMaterial.DAY01);
    }

    /**
     * �Y������1����ݒ肷��
     *
     * @param val �Y������1��
     */
    public void setDAY01(String val) {
        set(Tbj38RdProgramMaterial.DAY01, val);
    }

    /**
     * �Y������2�����擾����
     *
     * @return �Y������2��
     */
    public String getDAY02() {
        return (String) get(Tbj38RdProgramMaterial.DAY02);
    }

    /**
     * �Y������2����ݒ肷��
     *
     * @param val �Y������2��
     */
    public void setDAY02(String val) {
        set(Tbj38RdProgramMaterial.DAY02, val);
    }

    /**
     * �Y������3�����擾����
     *
     * @return �Y������3��
     */
    public String getDAY03() {
        return (String) get(Tbj38RdProgramMaterial.DAY03);
    }

    /**
     * �Y������3����ݒ肷��
     *
     * @param val �Y������3��
     */
    public void setDAY03(String val) {
        set(Tbj38RdProgramMaterial.DAY03, val);
    }

    /**
     * �Y������4�����擾����
     *
     * @return �Y������4��
     */
    public String getDAY04() {
        return (String) get(Tbj38RdProgramMaterial.DAY04);
    }

    /**
     * �Y������4����ݒ肷��
     *
     * @param val �Y������4��
     */
    public void setDAY04(String val) {
        set(Tbj38RdProgramMaterial.DAY04, val);
    }

    /**
     * �Y������5�����擾����
     *
     * @return �Y������5��
     */
    public String getDAY05() {
        return (String) get(Tbj38RdProgramMaterial.DAY05);
    }

    /**
     * �Y������5����ݒ肷��
     *
     * @param val �Y������5��
     */
    public void setDAY05(String val) {
        set(Tbj38RdProgramMaterial.DAY05, val);
    }

    /**
     * �Y������6�����擾����
     *
     * @return �Y������6��
     */
    public String getDAY06() {
        return (String) get(Tbj38RdProgramMaterial.DAY06);
    }

    /**
     * �Y������6����ݒ肷��
     *
     * @param val �Y������6��
     */
    public void setDAY06(String val) {
        set(Tbj38RdProgramMaterial.DAY06, val);
    }

    /**
     * �Y������7�����擾����
     *
     * @return �Y������7��
     */
    public String getDAY07() {
        return (String) get(Tbj38RdProgramMaterial.DAY07);
    }

    /**
     * �Y������7����ݒ肷��
     *
     * @param val �Y������7��
     */
    public void setDAY07(String val) {
        set(Tbj38RdProgramMaterial.DAY07, val);
    }

    /**
     * �Y������8�����擾����
     *
     * @return �Y������8��
     */
    public String getDAY08() {
        return (String) get(Tbj38RdProgramMaterial.DAY08);
    }

    /**
     * �Y������8����ݒ肷��
     *
     * @param val �Y������8��
     */
    public void setDAY08(String val) {
        set(Tbj38RdProgramMaterial.DAY08, val);
    }

    /**
     * �Y������9�����擾����
     *
     * @return �Y������9��
     */
    public String getDAY09() {
        return (String) get(Tbj38RdProgramMaterial.DAY09);
    }

    /**
     * �Y������9����ݒ肷��
     *
     * @param val �Y������9��
     */
    public void setDAY09(String val) {
        set(Tbj38RdProgramMaterial.DAY09, val);
    }

    /**
     * �Y������10�����擾����
     *
     * @return �Y������10��
     */
    public String getDAY10() {
        return (String) get(Tbj38RdProgramMaterial.DAY10);
    }

    /**
     * �Y������10����ݒ肷��
     *
     * @param val �Y������10��
     */
    public void setDAY10(String val) {
        set(Tbj38RdProgramMaterial.DAY10, val);
    }

    /**
     * �Y������11�����擾����
     *
     * @return �Y������11��
     */
    public String getDAY11() {
        return (String) get(Tbj38RdProgramMaterial.DAY11);
    }

    /**
     * �Y������11����ݒ肷��
     *
     * @param val �Y������11��
     */
    public void setDAY11(String val) {
        set(Tbj38RdProgramMaterial.DAY11, val);
    }

    /**
     * �Y������12�����擾����
     *
     * @return �Y������12��
     */
    public String getDAY12() {
        return (String) get(Tbj38RdProgramMaterial.DAY12);
    }

    /**
     * �Y������12����ݒ肷��
     *
     * @param val �Y������12��
     */
    public void setDAY12(String val) {
        set(Tbj38RdProgramMaterial.DAY12, val);
    }

    /**
     * �Y������13�����擾����
     *
     * @return �Y������13��
     */
    public String getDAY13() {
        return (String) get(Tbj38RdProgramMaterial.DAY13);
    }

    /**
     * �Y������13����ݒ肷��
     *
     * @param val �Y������13��
     */
    public void setDAY13(String val) {
        set(Tbj38RdProgramMaterial.DAY13, val);
    }

    /**
     * �Y������14�����擾����
     *
     * @return �Y������14��
     */
    public String getDAY14() {
        return (String) get(Tbj38RdProgramMaterial.DAY14);
    }

    /**
     * �Y������14����ݒ肷��
     *
     * @param val �Y������14��
     */
    public void setDAY14(String val) {
        set(Tbj38RdProgramMaterial.DAY14, val);
    }

    /**
     * �Y������15�����擾����
     *
     * @return �Y������15��
     */
    public String getDAY15() {
        return (String) get(Tbj38RdProgramMaterial.DAY15);
    }

    /**
     * �Y������15����ݒ肷��
     *
     * @param val �Y������15��
     */
    public void setDAY15(String val) {
        set(Tbj38RdProgramMaterial.DAY15, val);
    }

    /**
     * �Y������16�����擾����
     *
     * @return �Y������16��
     */
    public String getDAY16() {
        return (String) get(Tbj38RdProgramMaterial.DAY16);
    }

    /**
     * �Y������16����ݒ肷��
     *
     * @param val �Y������16��
     */
    public void setDAY16(String val) {
        set(Tbj38RdProgramMaterial.DAY16, val);
    }

    /**
     * �Y������17�����擾����
     *
     * @return �Y������17��
     */
    public String getDAY17() {
        return (String) get(Tbj38RdProgramMaterial.DAY17);
    }

    /**
     * �Y������17����ݒ肷��
     *
     * @param val �Y������17��
     */
    public void setDAY17(String val) {
        set(Tbj38RdProgramMaterial.DAY17, val);
    }

    /**
     * �Y������18�����擾����
     *
     * @return �Y������18��
     */
    public String getDAY18() {
        return (String) get(Tbj38RdProgramMaterial.DAY18);
    }

    /**
     * �Y������18����ݒ肷��
     *
     * @param val �Y������18��
     */
    public void setDAY18(String val) {
        set(Tbj38RdProgramMaterial.DAY18, val);
    }

    /**
     * �Y������19�����擾����
     *
     * @return �Y������19��
     */
    public String getDAY19() {
        return (String) get(Tbj38RdProgramMaterial.DAY19);
    }

    /**
     * �Y������19����ݒ肷��
     *
     * @param val �Y������19��
     */
    public void setDAY19(String val) {
        set(Tbj38RdProgramMaterial.DAY19, val);
    }

    /**
     * �Y������20�����擾����
     *
     * @return �Y������20��
     */
    public String getDAY20() {
        return (String) get(Tbj38RdProgramMaterial.DAY20);
    }

    /**
     * �Y������20����ݒ肷��
     *
     * @param val �Y������20��
     */
    public void setDAY20(String val) {
        set(Tbj38RdProgramMaterial.DAY20, val);
    }

    /**
     * �Y������21�����擾����
     *
     * @return �Y������21��
     */
    public String getDAY21() {
        return (String) get(Tbj38RdProgramMaterial.DAY21);
    }

    /**
     * �Y������21����ݒ肷��
     *
     * @param val �Y������21��
     */
    public void setDAY21(String val) {
        set(Tbj38RdProgramMaterial.DAY21, val);
    }

    /**
     * �Y������22�����擾����
     *
     * @return �Y������22��
     */
    public String getDAY22() {
        return (String) get(Tbj38RdProgramMaterial.DAY22);
    }

    /**
     * �Y������22����ݒ肷��
     *
     * @param val �Y������22��
     */
    public void setDAY22(String val) {
        set(Tbj38RdProgramMaterial.DAY22, val);
    }

    /**
     * �Y������23�����擾����
     *
     * @return �Y������23��
     */
    public String getDAY23() {
        return (String) get(Tbj38RdProgramMaterial.DAY23);
    }

    /**
     * �Y������23����ݒ肷��
     *
     * @param val �Y������23��
     */
    public void setDAY23(String val) {
        set(Tbj38RdProgramMaterial.DAY23, val);
    }

    /**
     * �Y������24�����擾����
     *
     * @return �Y������24��
     */
    public String getDAY24() {
        return (String) get(Tbj38RdProgramMaterial.DAY24);
    }

    /**
     * �Y������24����ݒ肷��
     *
     * @param val �Y������24��
     */
    public void setDAY24(String val) {
        set(Tbj38RdProgramMaterial.DAY24, val);
    }

    /**
     * �Y������25�����擾����
     *
     * @return �Y������25��
     */
    public String getDAY25() {
        return (String) get(Tbj38RdProgramMaterial.DAY25);
    }

    /**
     * �Y������25����ݒ肷��
     *
     * @param val �Y������25��
     */
    public void setDAY25(String val) {
        set(Tbj38RdProgramMaterial.DAY25, val);
    }

    /**
     * �Y������26�����擾����
     *
     * @return �Y������26��
     */
    public String getDAY26() {
        return (String) get(Tbj38RdProgramMaterial.DAY26);
    }

    /**
     * �Y������26����ݒ肷��
     *
     * @param val �Y������26��
     */
    public void setDAY26(String val) {
        set(Tbj38RdProgramMaterial.DAY26, val);
    }

    /**
     * �Y������27�����擾����
     *
     * @return �Y������27��
     */
    public String getDAY27() {
        return (String) get(Tbj38RdProgramMaterial.DAY27);
    }

    /**
     * �Y������27����ݒ肷��
     *
     * @param val �Y������27��
     */
    public void setDAY27(String val) {
        set(Tbj38RdProgramMaterial.DAY27, val);
    }

    /**
     * �Y������28�����擾����
     *
     * @return �Y������28��
     */
    public String getDAY28() {
        return (String) get(Tbj38RdProgramMaterial.DAY28);
    }

    /**
     * �Y������28����ݒ肷��
     *
     * @param val �Y������28��
     */
    public void setDAY28(String val) {
        set(Tbj38RdProgramMaterial.DAY28, val);
    }

    /**
     * �Y������29�����擾����
     *
     * @return �Y������29��
     */
    public String getDAY29() {
        return (String) get(Tbj38RdProgramMaterial.DAY29);
    }

    /**
     * �Y������29����ݒ肷��
     *
     * @param val �Y������29��
     */
    public void setDAY29(String val) {
        set(Tbj38RdProgramMaterial.DAY29, val);
    }

    /**
     * �Y������30�����擾����
     *
     * @return �Y������30��
     */
    public String getDAY30() {
        return (String) get(Tbj38RdProgramMaterial.DAY30);
    }

    /**
     * �Y������30����ݒ肷��
     *
     * @param val �Y������30��
     */
    public void setDAY30(String val) {
        set(Tbj38RdProgramMaterial.DAY30, val);
    }

    /**
     * �Y������31�����擾����
     *
     * @return �Y������31��
     */
    public String getDAY31() {
        return (String) get(Tbj38RdProgramMaterial.DAY31);
    }

    /**
     * �Y������31����ݒ肷��
     *
     * @param val �Y������31��
     */
    public void setDAY31(String val) {
        set(Tbj38RdProgramMaterial.DAY31, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj38RdProgramMaterial.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj38RdProgramMaterial.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj38RdProgramMaterial.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj38RdProgramMaterial.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj38RdProgramMaterial.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj38RdProgramMaterial.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj38RdProgramMaterial.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj38RdProgramMaterial.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj38RdProgramMaterial.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj38RdProgramMaterial.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj38RdProgramMaterial.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj38RdProgramMaterial.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj38RdProgramMaterial.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj38RdProgramMaterial.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj38RdProgramMaterial.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj38RdProgramMaterial.UPDID, val);
    }

}
