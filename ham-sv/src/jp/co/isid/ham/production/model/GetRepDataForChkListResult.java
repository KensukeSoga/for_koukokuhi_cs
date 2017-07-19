package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu2FHmokVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����@�N�����f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetRepDataForChkListResult  extends AbstractServiceResult {

    /* =============================================================================================*/
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** R3���̃f�[�^���X�g */
    private List<RepDataForChkListR3VO> _repDataForChkListR3 = null;
    /** HAM���̃f�[�^���X�g */
    private List<RepDataForChkListHAMVO> _repDataForChkListHAM = null;
    /** ��ڃ}�X�^�̃f�[�^���X�g */
    private List<RepaVbjaMeu07SikKrSprdVO> _repaVbjaMeu07SikKrSprd = null;
    /** �o���g�D�W�J�e�[�u���̃f�[�^���X�g */
    private List<RepaVbjaMeu2FHmokVO> _repaVbjaMeu2FHmok = null;
//    /** �l���VIEW�f�[�^���X�g */
//    private List<Vbj01AccUserVO> _vbj01AccUser = null;
    /** �ŋ敪�^���̂̃f�[�^���X�g */
    private List<RepaVbjaMeu29CcVO> _repaVbjaMeu29Cc = null;


    /**
     * R3���̃w�b�_�p�f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepDataForChkListR3VO> getRepDataForChkListR3() {
        return _repDataForChkListR3;
    }

    /**
     * R3���̃w�b�_�p�f�[�^���X�g��ݒ肵�܂�
     * @param repDataForCostMngHeader
     */
    public void setRepDataForChkListR3(List<RepDataForChkListR3VO> repDataForChkListR3) {
        _repDataForChkListR3 = repDataForChkListR3;
    }

    /**
     * HAM���̖��חp�f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepDataForChkListHAMVO> getRepDataForChkListHAM() {
        return _repDataForChkListHAM;
    }

    /**
     * HAM���̖��חp�f�[�^���X�g��ݒ肵�܂�
     * @param repDataForCostMngDetails
     */
    public void setRepDataForChkListHAM(List<RepDataForChkListHAMVO> repDataForChkListHAM) {
        _repDataForChkListHAM = repDataForChkListHAM;
    }

    /**
     * ��ڃ}�X�^�f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepaVbjaMeu07SikKrSprdVO> getRepaVbjaMeu07SikKrSprd() {
        return _repaVbjaMeu07SikKrSprd;
    }

    /**
     * ��ڃ}�X�^�f�[�^���X�g��ݒ肵�܂�
     * @param repaVbjaMeu07SikKrSprd
     */
    public void setRepaVbjaMeu07SikKrSprd(List<RepaVbjaMeu07SikKrSprdVO> repaVbjaMeu07SikKrSprd) {
        _repaVbjaMeu07SikKrSprd = repaVbjaMeu07SikKrSprd;
    }

    /**
     * �o���g�D�W�J�e�[�u���f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepaVbjaMeu2FHmokVO> getRepaVbjaMeu2FHmok() {
        return _repaVbjaMeu2FHmok;
    }

    /**
     * �o���g�D�W�J�e�[�u�����X�g��ݒ肵�܂�
     * @param repaVbjaMeu2FHmok
     */
    public void setRepaVbjaMeu2FHmok(List<RepaVbjaMeu2FHmokVO> repaVbjaMeu2FHmok) {
        _repaVbjaMeu2FHmok = repaVbjaMeu2FHmok;
    }

//    /**
//     * �l���VIEW�e�[�u���f�[�^���X�g���擾���܂�
//     * @return
//     */
//    public List<Vbj01AccUserVO> getVbj01AccUser() {
//        return _vbj01AccUser;
//    }
//
//    /**
//     * �l���VIEW�e�[�u�����X�g��ݒ肵�܂�
//     * @param vbj01AccUser
//     */
//    public void setVbj01AccUser(List<Vbj01AccUserVO> vbj01AccUser) {
//        _vbj01AccUser = vbj01AccUser;
//    }

    /**
     * �ŋ敪�^���̃f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepaVbjaMeu29CcVO> getRepaVbjaMeu29Cc() {
        return _repaVbjaMeu29Cc;
    }

    /**
     * �ŋ敪�^���̃��X�g��ݒ肵�܂�
     * @param repaVbjaMeu29Cc
     */
    public void setRepaVbjaMeu29Cc(List<RepaVbjaMeu29CcVO> repaVbjaMeu29Cc) {
        _repaVbjaMeu29Cc = repaVbjaMeu29Cc;
    }

}
