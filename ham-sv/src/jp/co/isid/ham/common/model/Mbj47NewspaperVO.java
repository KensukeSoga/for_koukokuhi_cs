package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj47Newspaper;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �V���}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/09/17 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj47NewspaperVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj47NewspaperVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new Mbj47NewspaperVO();
    }

    /**
     * �}�̎�ʃR�[�h���擾����
     *
     * @return �}�̎�ʃR�[�h
     */
    public String getNPCD()
    {
        return (String) get(Mbj47Newspaper.NPCD);
    }

    /**
     * �}�̎�ʃR�[�h��ݒ肷��
     *
     * @param val �}�̎�ʃR�[�h
     */
    public void setNPCD(String val)
    {
        set(Mbj47Newspaper.NPCD, val);
    }

    /**
     * �}�̗����̂��擾����
     *
     * @return �}�̗�����
     */
    public String getRNAME()
    {
        return (String) get(Mbj47Newspaper.RNAME);
    }

    /**
     * �}�̗����̂�ݒ肷��
     *
     * @param val �}�̗�����
     */
    public void setRNAME(String val)
    {
        set(Mbj47Newspaper.RNAME, val);
    }

    /**
     * �G���A���擾����
     *
     * @return �G���A
     */
    public String getAREA()
    {
        return (String) get(Mbj47Newspaper.AREA);
    }

    /**
     * �G���A��ݒ肷��
     *
     * @param val �G���A
     */
    public void setAREA(String val)
    {
        set(Mbj47Newspaper.AREA, val);
    }

    /**
     * �˗���R�[�h���擾����
     *
     * @return �˗���R�[�h
     */
    public String getIRAISAKICODE()
    {
        return (String) get(Mbj47Newspaper.IRAISAKICODE);
    }

    /**
     * �˗���R�[�h��ݒ肷��
     *
     * @param val �˗���R�[�h
     */
    public void setIRAISAKICODE(String val)
    {
        set(Mbj47Newspaper.IRAISAKICODE, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj47Newspaper.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj47Newspaper.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM()
    {
        return (String) get(Mbj47Newspaper.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val)
    {
        set(Mbj47Newspaper.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj47Newspaper.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val)
    {
        set(Mbj47Newspaper.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj47Newspaper.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val)
    {
        set(Mbj47Newspaper.UPDID, val);
    }

}
