package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I��AllocationPicture�ԑg�f�ޏ�񌟍�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdAllocationPictureProgramMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindRdAllocationPictureProgramMaterialVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindRdAllocationPictureProgramMaterialVO();
    }

    /**
     * ���W�I�ԑgSEQNO���擾����
     * @return BigDecimal ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.RDSEQNO);
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     * @param val BigDecimal ���W�I�ԑgSEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial.RDSEQNO, val);
    }

    /**
     * �N�����擾����
     * @return String �N��
     */
    public String getYEARMONTH() {
        return (String) get(Tbj38RdProgramMaterial.YEARMONTH);
    }

    /**
     * �N����ݒ肷��
     * @param val String �N��
     */
    public void setYEARMONTH(String val) {
        set(Tbj38RdProgramMaterial.YEARMONTH, val);
    }

    /**
     * �gSEQNO���擾����
     * @return BigDecimal �gSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getWAKUSEQ() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.WAKUSEQ);
    }

    /**
     * �gSEQNO��ݒ肷��
     * @param val BigDecimal �gSEQNO
     */
    public void setWAKUSEQ(BigDecimal val) {
        set(Tbj38RdProgramMaterial.WAKUSEQ, val);
    }

    /**
     * ���t���擾����
     * @return BigDecimal ���t
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNO() {
        return (BigDecimal) get(Mbj51Natural.NO);
    }

    /**
     * ���t��ݒ肷��
     * @param val BigDecimal ���t
     */
    public void setNO(BigDecimal val) {
        set(Mbj51Natural.NO, val);
    }

    /**
     * 10��CM�R�[�h���擾����
     * @return String 10��CM�R�[�h
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }

    /**
     * 10��CM�R�[�h��ݒ肷��
     * @param val String 10��CM�R�[�h
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

}
