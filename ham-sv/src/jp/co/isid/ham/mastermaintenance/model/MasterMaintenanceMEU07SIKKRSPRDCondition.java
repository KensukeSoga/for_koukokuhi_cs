package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �o���g�D�W�J�e�[�u������Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/05/02 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceMEU07SIKKRSPRDCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �����g�D�R�[�h���X�g */
    private List<String> _SIKCDList = null;

    /** ���t */
    private String _HIDUKE = null;

    /**
     * �����g�D�R�[�h���X�g���擾���܂�
     * @return _SIKCDList
     */
    public List<String> getSIKCDList()
    {
        return _SIKCDList;
    }

    /**
     * �����g�D�R�[�h���X�g��ݒ肵�܂�
     * @param data �Z�b�g���� _SIKCDList
     */
    public void setSIKCDList(List<String> data)
    {
        _SIKCDList = data;
    }

    /**
     * ���t���擾����
     *
     * @return ���t
     */
    public String getHIDUKE()
    {
        return _HIDUKE;
    }

    /**
     * ���t��ݒ肷��
     *
     * @param val ���t
     */
    public void setHIDUKE(String val)
    {
        _HIDUKE = val;
    }

}
