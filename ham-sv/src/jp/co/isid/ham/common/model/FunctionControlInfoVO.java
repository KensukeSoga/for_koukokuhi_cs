package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �@�\������VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/11 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FunctionControlInfoVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FunctionControlInfoVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new FunctionControlInfoVO();
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj33FunctionControl.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val)
    {
        set(Mbj33FunctionControl.HAMID, val);
    }

    /**
     * �@�\�R�[�h���擾����
     *
     * @return �@�\�R�[�h
     */
    public String getFUNCCD()
    {
        return (String) get(Mbj33FunctionControl.FUNCCD);
    }

    /**
     * �@�\�R�[�h��ݒ肷��
     *
     * @param val �@�\�R�[�h
     */
    public void setFUNCCD(String val)
    {
        set(Mbj33FunctionControl.FUNCCD, val);
    }

    /**
     * �@�\��ʂ��擾����
     *
     * @return ���
     */
    public String getFUNCTYPE()
    {
        return (String) get(Mbj33FunctionControl.FUNCTYPE);
    }

    /**
     * �@�\��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setFUNCTYPE(String val)
    {
        set(Mbj33FunctionControl.FUNCTYPE, val);
    }

    /**
     * ������擾����
     *
     * @return ����
     */
    public String getCONTROL()
    {
        return (String) get(Mbj33FunctionControl.CONTROL);
    }

    /**
     * �����ݒ肷��
     *
     * @param val ����
     */
    public void setCONTROL(String val)
    {
        set(Mbj33FunctionControl.CONTROL, val);
    }

    /**
     * �@�\�����擾����
     *
     * @return �@�\��
     */
    public String getFUNCNM()
    {
        return (String) get(Mbj34FunctionControlItem.FUNCNM);
    }

    /**
     * �@�\����ݒ肷��
     *
     * @param val �@�\��
     */
    public void setFUNCNM(String val)
    {
        set(Mbj34FunctionControlItem.FUNCNM, val);
    }

    /**
     * �t�H�[���t�@�C��ID���擾����
     *
     * @return �t�H�[���t�@�C��ID
     */
    public String getFORMID()
    {
        return (String) get(Mbj34FunctionControlItem.FORMID);
    }

    /**
     * �t�H�[���t�@�C��ID��ݒ肷��
     *
     * @param val �t�H�[���t�@�C��ID
     */
    public void setFORMID(String val)
    {
        set(Mbj34FunctionControlItem.FORMID, val);
    }

    /**
     * �I�u�W�F�N�g�����擾����
     *
     * @return �I�u�W�F�N�g��
     */
    public String getOBJNAME()
    {
        return (String) get(Mbj34FunctionControlItem.OBJNAME);
    }

    /**
     * �I�u�W�F�N�g����ݒ肷��
     *
     * @param val �I�u�W�F�N�g��
     */
    public void setOBJNAME(String val)
    {
        set(Mbj34FunctionControlItem.OBJNAME, val);
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO()
    {
        return (BigDecimal) get(Mbj34FunctionControlItem.SORTNO);
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param val �\�[�gNo
     */
    public void setSORTNO(BigDecimal val)
    {
        set(Mbj34FunctionControlItem.SORTNO, val);
    }


}
