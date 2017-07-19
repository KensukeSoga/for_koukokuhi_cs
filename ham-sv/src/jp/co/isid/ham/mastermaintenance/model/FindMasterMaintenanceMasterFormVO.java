package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * MasterForm�����f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/04 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMasterFormVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �@�\������VO���X�g */
    private List<FunctionControlInfoVO> _findFunctionControlInfoList;

    /** �Z�L�����e�B���VO���X�g */
    private List<SecurityInfoVO> _findSecurityInfoList;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMasterMaintenanceMasterFormVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new FindMasterMaintenanceMasterFormVO();
    }

    /**
     * �@�\������VO���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _findFunctionControlInfoList
     */
    public void setFindFunctionControlInfoList(List<FunctionControlInfoVO> voList)
    {
        _findFunctionControlInfoList = voList;
    }

    /**
     * �@�\������VO���X�g���擾���܂�
     * @return _findFunctionControlInfoList
     */
    public List<FunctionControlInfoVO> getFindFunctionControlInfoList()
    {
        return _findFunctionControlInfoList;
    }

    /**
     * �Z�L�����e�B���VO���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _findSecurityInfoList
     */
    public void setFindSecurityInfoList(List<SecurityInfoVO> voList)
    {
        _findSecurityInfoList = voList;
    }

    /**
     * �Z�L�����e�B���VO���X�g���擾���܂�
     * @return _findSecurityInfoList
     */
    public List<SecurityInfoVO> getFindSecurityInfoList()
    {
        return _findSecurityInfoList;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy()
    {
        return _dummy;
    }

}
